using AuthDemoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemoApi.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
    }

}
