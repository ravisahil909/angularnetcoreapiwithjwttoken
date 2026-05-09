using AuthDemoApi.Models;
using AuthDemoApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly ICacheService _cache;

        public AppointmentService(IAppointmentRepository repo, ICacheService cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<List<Appointment>> GetAppointments(int patientId)
        {
            return await _cache.GetOrSetAsync(
                $"appointments_{patientId}",
                () => _repo.GetAppointments(patientId),
                5);
        }
    }
}
