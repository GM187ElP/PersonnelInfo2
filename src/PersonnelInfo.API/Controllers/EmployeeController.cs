using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Infrastructure;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonnelInfo.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    readonly ILogger<EmployeeController> _logger;
    readonly IEmployeeServices _services;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services)
    {
        _logger = logger;
        _services = services;
    }

    //// GET: api/<EmployeeController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    // GET api/<EmployeeController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken = default)
    {
        if (int.TryParse(id, out int parsedId))
        {
            var employee = await _services.GetByIdAsync(parsedId, cancellationToken);
            return Ok(employee);
        }

        return BadRequest("Invalid Id format.");
    }



    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> Add(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
    {
        var isAdded = await _services.AddAsync(addDto, cancellationToken);
        if (isAdded) return CreatedAtAction(nameof(GetById), new { id = _services.GetByNationalId(addDto.NationalId).Id }, new { message = $"Employee with name: {addDto.FirstName} {addDto.LastName} is added successfully." });
        return BadRequest(new { message = "Failed to add the employee. Please check the provided data." });
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _services.GetAllAsync();
        return Ok(employees);
    }

    //// PUT api/<EmployeeController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<EmployeeController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
