using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonnelInfo.Razor.DTOs.Entities.Employees;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PersonnelInfo.Razor.Pages.Employee
{
    public class IndexModel : BaseEmployeePageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public EmployeeDto Employee { get; set; } = new();
        public List<EmployeeDto> Employees { get; set; } = [];
        public List<string> Headers { get; set; } = [];
        public List<PropertyInfo> DtoProperties { get; set; } = [];

        public async Task OnGet()
        {
            DtoProperties = typeof(EmployeeDto).GetProperties().ToList();
            Headers = GetHeaders(typeof(EmployeeDto));
            var client = _httpClientFactory.CreateClient("API");
            var response = await client.GetAsync("api/Employee/GetAll");

            if (!response.IsSuccessStatusCode)
                Employees = await response.Content.ReadFromJsonAsync<List<EmployeeDto>>() ?? [];
        }

        private List<string> GetHeaders(Type entity)
        {
            var properties = entity.GetProperties()
                .Select(prop =>
            {
                var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                return displayAttr != null ? displayAttr.Name : prop.Name;
            }).ToList() ?? throw new Exception($"{entity.Name} has no properties");

            if (!properties.Any())
                throw new Exception($"{entity.Name} has no properties");

            return properties!;
        }
    }
}

