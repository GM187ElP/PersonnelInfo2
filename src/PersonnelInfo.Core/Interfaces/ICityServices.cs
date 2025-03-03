using PersonnelInfo.Core.DTOs.Entities.Cities;

namespace PersonnelInfo.Application.Services;

public interface ICityServices
{
    Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CityDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}