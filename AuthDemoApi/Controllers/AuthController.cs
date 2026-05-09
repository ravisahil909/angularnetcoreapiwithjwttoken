
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthDemoApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using AuthDemoApi.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using AuthDemoApi.Services;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AuthDemoApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IAuthService auth, ILogger<AuthController> logger)
    {
        _auth = auth;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest req, CancellationToken ct)
    {
        _logger.LogInformation("Login request received for {User}", req.Username);

        try
        {
            var result = await _auth.Login(req, ct);

            if (result == null)
            {
                _logger.LogWarning("Invalid login attempt for {User}", req.Username);
                return Unauthorized();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during login");
            return StatusCode(500);
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(TokenRequest req, CancellationToken ct)
    {
        var result = await _auth.Refresh(req, ct);

        if (result == null)
            return Unauthorized();

        return Ok(result);
    }
}