using AuthDemoApi.Data;
using AuthDemoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
