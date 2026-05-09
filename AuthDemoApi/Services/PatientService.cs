using AuthDemoApi.Models;
using AuthDemoApi.Repositories;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repo;
        private readonly ICacheService _cache;

        public PatientService(IPatientRepository repo, ICacheService cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _cache.GetOrSetAsync(
                $"patient_{id}",
                () => _repo.GetPatient(id),
                5);
        }
    }
}
