using Microsoft.AspNetCore.Mvc;

[Route("api/hello")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, World from .NET API!");
    }
}
