using Microsoft.AspNetCore.Mvc;

using Store.Shared.Models;

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

    public async Task<ActionResult<IReadOnlyCollection<Social>>> GetAsync()
    {
        return Ok(await _service.GetAsync());
    }
}
