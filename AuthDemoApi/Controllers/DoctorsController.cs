using AuthDemoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthDemoApi.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _docservice;

        public DoctorsController(DoctorService docservice)
        {
            _docservice = docservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _docservice.GetDoctors());
        }
    }
}
