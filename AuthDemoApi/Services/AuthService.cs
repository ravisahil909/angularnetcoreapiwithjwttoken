using AuthDemoApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using AuthDemoApi.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        string CreateToken(string user, string role)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[]
                {
                new Claim(ClaimTypes.Name,user),
                new Claim(ClaimTypes.Role,role)
                },
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<object> Login(LoginRequest req, CancellationToken ct)
        {
            var user =await _repo.GetUserByUsername(req.Username,ct);

            if (user == null || user.PasswordHash != req.Password)
                return null;

            var access = CreateToken(user.Username, user.Role);
            var refresh = Guid.NewGuid().ToString();

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _repo.UpdateUser(user, ct);
            

            return new
            {
                accessToken = access,
                refreshToken = refresh
            };
        }

        public async Task<object> Refresh(TokenRequest t,CancellationToken ct)
        {
            var user =await _repo.GetUserByRefreshToken(t.RefreshToken,ct);

            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                return null;

            var access = CreateToken(user.Username, user.Role);
            var refresh = Guid.NewGuid().ToString();

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _repo.UpdateUser(user, ct);
            

            return new
            {
                accessToken = access,
                refreshToken = refresh
            };
        }
    }
}
