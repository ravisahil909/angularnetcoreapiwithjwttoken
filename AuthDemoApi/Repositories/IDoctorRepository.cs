using AuthDemoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetDoctors();
    }
}
