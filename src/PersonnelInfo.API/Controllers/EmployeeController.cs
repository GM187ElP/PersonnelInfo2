using Microsoft.AspNetCore.Mvc;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonnelInfo.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    readonly ILogger<EmployeeController> logger;
    readonly IEmployeeServices _services;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services) => (this.logger, _services) = (logger, services);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken = default)
    {
        if (int.TryParse(id, out int parsedId))
        {
            var employee = await _services.GetByIdAsync(parsedId, cancellationToken);
            if (employee != null)
            {
                logger.LogInformation("Retrieved employee with ID: {EmployeeId}", parsedId);
                return Ok(employee);
            }

            logger.LogWarning("Employee not found with ID: {EmployeeId}", parsedId);
            return NotFound($"Employee with ID {parsedId} not found.");
        }

        logger.LogWarning("Invalid ID format received: {Id}", id);
        return BadRequest("Invalid Id format.");
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _services.AddAsync(dto, cancellationToken);

        if (result.Success)
        {
            logger.LogInformation("Successfully added employee {FirstName} {LastName} with ID: {EmployeeId}", dto.FirstName, dto.LastName, result.Data);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, new { message = $"Employee {dto.FirstName} {dto.LastName} was added successfully." });
        }

        logger.LogError("Failed to add employee {FirstName} {LastName}. Error: {Error}", dto.FirstName, dto.LastName, result.ErrorMessage ?? "Unknown error");
        return BadRequest(new { message = result.ErrorMessage ?? "Failed to add the employee. Please check the provided data." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int page = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _services.GetAllAsync(page, pageSize, cancellationToken);
            var employees = result.Data as List<EmployeeDto>;
            return Ok(new PagedResult<EmployeeDto>
            {
                TotalCount = result.TotalCount,
                Items = employees ?? []
            });
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499); // 499 is used by some proxies to indicate client closed request
        }
    }


    //[HttpPost("update/{id}")]
    //public async Task<IActionResult> UpdateAsync([FromRoute]long id, CancellationToken cancellationToken = default)
    //{
    //    var result = await _services.UpdateAsync(EmployeeDto,cancellationToken);
    //}
}
