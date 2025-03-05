
namespace PersonnelInfo.Razor.DTOs.Entities.Cities;

public class AddCityDto
{
    public string Name { get; set; } = string.Empty;
    public int ProvinceId { get; set; } 
    public bool IsCapital { get; set; }
}