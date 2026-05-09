using AuthDemoApi.Models;
using AuthDemoApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _repo;
        private readonly ICacheService _cache;

        public DepartmentService(IDepartmentRepository repo, ICacheService cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _cache.GetOrSetAsync(
                "departments_list",
                () => _repo.GetDepartments(),
                10);
        }
    }
}
