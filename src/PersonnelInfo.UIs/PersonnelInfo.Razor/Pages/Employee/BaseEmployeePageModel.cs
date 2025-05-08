using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class BaseEmployeePageModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient client;

    public BaseEmployeePageModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        client = _httpClientFactory.CreateClient("API");
        Cities = new List<SelectListItem>(); // avoid null ref
    }

    public List<SelectListItem> Cities { get; set; }

    public async Task LoadCitiesAsync()
    {
        var response = await client.GetAsync("api/Employee/GetAll");
        if (response.IsSuccessStatusCode)
        {
            var cityList = await response.Content.ReadFromJsonAsync<List<string>>();
            Cities = cityList.Select(c => new SelectListItem { Text = c, Value = c }).ToList();
        }
    }
}
