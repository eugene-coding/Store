using Microsoft.AspNetCore.Mvc;

using Store.Shared.Models;
using Store.Shared.Services;

namespace Store.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SocialController : ControllerBase
{
    private readonly ISocialService _service;

    public SocialController(ISocialService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Social>> GetNoTrackingAsync()
    {
        return await _service.GetNoTrackingAsync();
    }
}
