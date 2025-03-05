using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Cities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.Application.Services;

public class CityServices : ICityServices
{
    private readonly ICityRepository _repository;

    public CityServices(ICityRepository repository, IUnitOfWork unitOfWork) => _repository = repository;

    public async Task<Dictionary<string, IEnumerable<string>>> GetAllAsync(CancellationToken cancellationToken = default) =>
             await _repository.GetAllAsync(cancellationToken);

    public async Task<CityDto> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
             Mapper.MapToDto(await _repository.GetByIdAsync(id, cancellationToken), new CityDto());
}
