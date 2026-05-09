using AuthDemoApi.Data;
using AuthDemoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DoctorRepository> _logger;

        public DoctorRepository(AppDbContext context, ILogger<DoctorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            _logger.LogInformation("Fetching doctors from DATABASE");

            return await _context.Doctors.ToListAsync();
        }
    }
}
