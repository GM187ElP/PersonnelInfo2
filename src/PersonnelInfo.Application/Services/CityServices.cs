using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Cities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Application.Services;

public class CityServices : ICityServices
{
    private readonly ICityRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CityServices(ICityRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    //public async Task AddAsync(AddCityDto addDto, CancellationToken cancellationToken = default)
    //{
    //    var _entity = new City();
    //    _entity = Mapper.MapToEntity(addDto, _entity);

    //    await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
    //    {
    //        await _repository.AddAsync(_entity, cancellationToken);
    //    }, cancellationToken);
    //}

    //public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    //{
    //    await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
    //    {
    //        await _repository.DeleteByIdAsync(id, cancellationToken);
    //    }, cancellationToken);
    //}

    public async Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);
        var CitysDto = new List<CityDto>();
        entityList.ForEach(e => CitysDto.Add(Mapper.MapToDto(e, new CityDto())));
        return CitysDto;
    }

    public async Task<CityDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return Mapper.MapToDto(entity, new CityDto());
    }

    //public async Task UpdateAsync(CityDto updateDto, CancellationToken cancellationToken = default)
    //{
    //    var entity = Mapper.MapToEntity(updateDto, new City());

    //    await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
    //    {
    //        await _repository.UpdateAsync(entity, cancellationToken);
    //    }, cancellationToken);
    //}
}
