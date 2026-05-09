using AuthDemoApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsername(string username, CancellationToken ct);

        Task<User?> GetUserByRefreshToken(string refreshToken, CancellationToken ct);

        Task UpdateUser(User user, CancellationToken ct);

    }
}
