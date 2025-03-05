//using Microsoft.AspNetCore.Mvc;
//using PersonnelInfo.Core.Interfaces;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace PersonnelInfo.API.Controllers;
//[ApiController]
//[Route("api/[controller]")]
//public class EmployeeController : ControllerBase
//{
//    readonly ILogger<EmployeeController> _logger;
//    readonly IEmployeeServices _services;

//    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services) => (_logger, _services) = (logger, services);

//    [HttpGet("{id}")]
//    [Route(nameof(GetById))]
//    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken = default)
//    {
//        if (int.TryParse(id, out int parsedId))
//        {
//            var employee = await _services.GetByIdAsync(parsedId, cancellationToken);
//            return Ok(employee);
//        }

//        return BadRequest("Invalid Id format.");
//    }


//    [HttpPost]
//    [Route("Add")]
//    public async Task<IActionResult> Add(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
//    {

//        var result = await _services.AddAsync(addDto, cancellationToken);
//        if (result) return CreatedAtAction(nameof(GetById), new { id = _services.GetByNationalId(addDto.NationalId).Id }, new { message = $"Employee with name: {addDto.FirstName} {addDto.LastName} is added successfully." });
//        return BadRequest(new { message = "Failed to add the employee. Please check the provided data." });
//    }

//    [HttpGet]
//    [Route("GetAll")]
//    public async Task<IActionResult> GetAll()
//    {
//        var employees = await _services.GetAllAsync();
//        return Ok(employees);
//    }
//}
