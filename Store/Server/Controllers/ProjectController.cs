using Microsoft.AspNetCore.Mvc;

using Store.Shared.Entities;

namespace Store.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Project>>> GetAsync()
    {
        return Ok(await _service.GetAsync());
    }

    [HttpGet("seo/{seo}")]
    public async Task<ActionResult<Project>> GetAsync(string seo)
    {
        var project = await _service.GetAsync(seo);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCountAsync()
    {
        return await _service.GetCountAsync();
    }

    [HttpGet("count/{count}")]
    public async Task<ActionResult<IEnumerable<Project>>> GetWithoutImagesAsync(int count)
    {
        return Ok(await _service.GetWithoutImagesAsync(count));
    }

    [HttpGet("count/{count}/skip/{skip}")]
    public async Task<ActionResult<IEnumerable<Project>>> GetWithoutImagesAsync(int count, int skip)
    {
        return Ok(await _service.GetWithoutImagesAsync(count, skip));
    }
}
