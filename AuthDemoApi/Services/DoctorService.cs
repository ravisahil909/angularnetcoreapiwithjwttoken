using AuthDemoApi.Models;
using AuthDemoApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public class DoctorService
    {


        private readonly IDoctorRepository _repo;
        private readonly ICacheService _cache;

        public DoctorService(IDoctorRepository repo, ICacheService cache)
        {
            _repo = repo;
            _cache = cache;
        }

        //public async Task<List<Doctor>> GetDoctors()
        //{
        //    return await _cache.GetOrSetAsync(
        //        "doctors_list",
        //        () => _repo.GetDoctors(),
        //        10);
        //}

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _repo.GetDoctors();
        }
    }
}
