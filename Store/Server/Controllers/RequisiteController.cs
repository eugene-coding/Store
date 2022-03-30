using Microsoft.AspNetCore.Mvc;

namespace Store.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequisiteController : ControllerBase
{
    private readonly IRequisiteService _service;

    public RequisiteController(IRequisiteService service)
    {
        _service = service;
    }

    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAsync());
    }
}
