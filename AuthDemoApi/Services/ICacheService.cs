using System.Threading.Tasks;
using System;

namespace AuthDemoApi.Services
{
    public interface ICacheService
    {
        Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> getData, int minutes = 5);

        Task RemoveAsync(string key);
    }
}
