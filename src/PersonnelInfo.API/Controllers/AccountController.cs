using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PersonnelInfo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("")]
    public IActionResult SignInAsync()
    {
        return Ok();
    }
}
