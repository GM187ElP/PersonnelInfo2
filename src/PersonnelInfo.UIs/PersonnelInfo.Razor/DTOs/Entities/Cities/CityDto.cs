using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Core.DTOs.Entities.Cities;

public class CityDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int? ProvinceId { get; set; } //nullable
    public bool? IsCapital { get; set; }
    public ICollection<Employee> BirthPlaces { get; set; }
    public ICollection<Employee> ShenasnameIssuedPlaces { get; set; }
}