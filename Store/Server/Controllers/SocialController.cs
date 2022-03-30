using Microsoft.AspNetCore.Mvc;

namespace Store.Server.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public class SocialController : ControllerBase
{
    private readonly ISocialService _service;

    public SocialController(ISocialService service)
    {
        _service = service;
    }

    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAsync());
    }
}
