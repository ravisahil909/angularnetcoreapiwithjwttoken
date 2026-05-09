using AuthDemoApi.Data;
using AuthDemoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace AuthDemoApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsername(string username, CancellationToken ct)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Username == username, ct);
        }

        public async Task<User?> GetUserByRefreshToken(string refreshToken, CancellationToken ct)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, ct);
        }

        public async Task UpdateUser(User user, CancellationToken ct)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(ct);
        }
    }
}
