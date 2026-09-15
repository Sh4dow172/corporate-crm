using System.Diagnostics.CodeAnalysis;
using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
[SuppressMessage("Maintainability", "CA1515")]
public sealed class LocationsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateLocationDto locationDto)
    {
        return Ok(Guid.NewGuid());
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateLocationDto locationDto)
    {
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        return NoContent();
    }
}