using System.Diagnostics.CodeAnalysis;
using DirectoryService.Contracts;
using DirectoryService.Core.Locations;
using DirectoryService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
[SuppressMessage("Maintainability", "CA1515")]
public sealed class LocationsController : ControllerBase
{
    private readonly LocationsService _locationsService;

    public LocationsController(LocationsService locationsService)
    {
        _locationsService = locationsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto locationDto, CancellationToken cancellationToken)
    {
        var id = await _locationsService.Create(locationDto, cancellationToken);
        return Ok(id);
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Array.Empty<Object>());
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