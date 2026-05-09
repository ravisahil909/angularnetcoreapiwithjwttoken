using AuthDemoApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public interface IAuthService
    {
        Task<object> Login(LoginRequest req, CancellationToken ct);

        Task<object> Refresh(TokenRequest req, CancellationToken ct);
    }
}
