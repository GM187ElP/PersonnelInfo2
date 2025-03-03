using Microsoft.AspNetCore.Mvc;
using PersonnelInfo.API.Controllers;
using PersonnelInfo.Core.DTOs.Entities.Employees;

namespace PersonnelInfo.Mvc.Controllers;
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IHttpClientFactory _clientFactory;

    public EmployeeController(ILogger<EmployeeController> logger, IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient("API");
        var response = await client.GetAsync("api/Employee/GetAll");

        if (response.IsSuccessStatusCode)
        {
            var employees = await response.Content.ReadFromJsonAsync<List<EmployeeDto>>();
            return View(employees);
        }

        return View(new List<EmployeeDto>());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] AddEmployeeDto dto)
    {
        var client = _clientFactory.CreateClient("API");
        var content=JsonContent.Create(dto);

        var response=await client.PostAsync("api/Employee/Add",content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return View(dto);
    }

    public IActionResult Delete(long id)
    {
        return View();
    }

    
    public IActionResult Delete()
    {
        return View();
    }

    public IActionResult Update(long id)
    {
        return View();
    }


    public IActionResult Update(EmployeeDto dto)
    {
        try
        {

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return View("Error");
        }
    }

}
