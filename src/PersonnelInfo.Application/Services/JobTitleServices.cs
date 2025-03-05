using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.JobTitles;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.Application.Services;

public class JobTitleServices : IJobTitleServices
{
    private readonly IJobTitleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public JobTitleServices(IJobTitleRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task AddAsync(AddJobTitleDto addDto, CancellationToken cancellationToken = default)
    {
        var _entity = new JobTitle();
        _entity = Mapper.MapToEntity(addDto, _entity);

        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.AddAsync(_entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.DeleteByIdAsync(id, cancellationToken);
        }, cancellationToken);
    }

    public async Task<List<JobTitleDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);
        var JobTitlesDto = new List<JobTitleDto>();
        entityList.ForEach(e => JobTitlesDto.Add(Mapper.MapToDto(e, new JobTitleDto())));
        return JobTitlesDto;
    }

    public async Task<JobTitleDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return Mapper.MapToDto(entity, new JobTitleDto());
    }

    public async Task UpdateAsync(JobTitleDto updateDto, CancellationToken cancellationToken = default)
    {
        var entity = Mapper.MapToEntity(updateDto, new JobTitle());

        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }, cancellationToken);
    }
}
