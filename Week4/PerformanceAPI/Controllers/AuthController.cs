
using Microsoft.AspNetCore.Mvc;

namespace PerformanceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    [BasicAuthentication]
    public IActionResult Login()
    {
        return Ok("Login successful");
    }
}
