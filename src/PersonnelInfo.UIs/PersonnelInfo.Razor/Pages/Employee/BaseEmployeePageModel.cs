using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonnelInfo.Razor.Pages.Employee
{
    public class BaseEmployeePageModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient client;
        public BaseEmployeePageModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient("API");
            Cities = GetCities() ?? [];
        }

        public List<SelectListItem> Cities { get; set; }

        private static List<SelectListItem> GetCities()
        {
            var response = client.GetAsync("api/Employee/GetAll");
            return null;
        }

    }
}
