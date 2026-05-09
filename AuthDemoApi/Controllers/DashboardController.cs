
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthDemoApi.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize(Roles = "admin")]
public class DashboardController : ControllerBase
{
[HttpGet("patients")]
public IActionResult Patients()
{
return Ok(new[]{"Patient1","Patient2","Patient3"});
}

[HttpGet("doctors")]
public IActionResult Doctors()
{
return Ok(new[]{"Dr Sharma","Dr Khan","Dr Patel"});
}

[HttpGet("appointments")]
public IActionResult Appointments()
{
return Ok(new[]{"Appointment1","Appointment2"});
}

[HttpGet("reports")]
public IActionResult Reports()
{
return Ok(new[]{"Blood Report","XRay Report"});
}
}
