using AuthDemoApi.Models;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatient(int id);
    }
}
