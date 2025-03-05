
namespace PersonnelInfo.Core.Entities;

public class City
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProvinceId { get; set; }
    public bool IsCapital { get; set; }
    public ICollection<Employee> BirthPlaces { get; set; } = [];
    public ICollection<Employee> ShenasnameIssuedPlaces { get; set; } = [];
}
