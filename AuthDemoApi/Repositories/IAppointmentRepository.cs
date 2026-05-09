using AuthDemoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointments(int patientId);
    }
}
