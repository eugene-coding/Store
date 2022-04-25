using Microsoft.AspNetCore.Mvc;

using Store.Shared.Models;
using Store.Shared.Services;

namespace Store.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BadgeController : ControllerBase
{
    private readonly IBadgeService _service;

    public BadgeController(IBadgeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Badge>> Get()
    {
        var result = await _service.GetNoTrackingAsync();

        return result ?? Enumerable.Empty<Badge>();
    }
}
