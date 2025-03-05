using Microsoft.AspNetCore.Mvc;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    readonly ILogger<CityController> _logger;
    readonly ICityServices _services;

    public CityController(ILogger<CityController> logger, ICityServices services) => (_logger, _services) = (logger, services);

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await _services.GetAllAsync(cancellationToken: cancellationToken);
        if (!result.Any())
            return NotFound();

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken = default)
    {
        var result = await _services.GetByIdAsync(id, cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

}
