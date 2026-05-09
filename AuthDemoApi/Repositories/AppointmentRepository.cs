using AuthDemoApi.Data;
using AuthDemoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAppointments(int patientId)
        {
            return await _context.Appointments
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }
    }
}
