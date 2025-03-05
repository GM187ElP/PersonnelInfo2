using PersonnelInfo.Core.DTOs.Entities.Cities;

namespace PersonnelInfo.Core.Interfaces;

public interface ICityServices
{
    Task<Dictionary<string, IEnumerable<string>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CityDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}