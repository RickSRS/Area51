using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Keycloak.Controller;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "This is a secure endpoint" });
    }
}