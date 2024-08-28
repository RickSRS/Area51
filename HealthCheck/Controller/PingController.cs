using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controller;

[Route("[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Ping()
    {
        return Ok(await Task.FromResult("Pong"));
    }
}