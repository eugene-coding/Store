using Microsoft.AspNetCore.Mvc;

using Store.Shared.Entities;

namespace Store.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public  class FaqController : ControllerBase
{
    private readonly IFaqService _service;

    public FaqController(IFaqService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Faq>>> GetAsync()
    {
        return Ok(await _service.GetAsync());
    }

    [HttpGet("block/{count:int}")]
    public async Task<ActionResult<IReadOnlyCollection<Faq>>> GetForBlockAsync(int count)
    {
        return Ok(await _service.GetForBlockAsync(count));
    }
}
