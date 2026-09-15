using System.Diagnostics.CodeAnalysis;
using DirectoryService.Contracts;
using DirectoryService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;
[ApiController]
[Route("[controller]")]
[SuppressMessage("Maintainability", "CA1515")]
public sealed class DepartmentsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateDepartmentDto departmentDto)
    {
        return Ok(Guid.NewGuid());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Array.Empty<Object>());
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateDepartmentDto departmentDto)
    {
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        return Ok();
    }
}