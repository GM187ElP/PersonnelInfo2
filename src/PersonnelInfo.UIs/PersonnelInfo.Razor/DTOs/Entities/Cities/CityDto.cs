
namespace PersonnelInfo.Razor.DTOs.Entities.Cities;

public class CityDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProvinceId { get; set; } 
    public bool IsCapital { get; set; }
}