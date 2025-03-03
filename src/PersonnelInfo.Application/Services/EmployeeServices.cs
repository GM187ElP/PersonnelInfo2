using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Application;
using PersonnelInfo.Shared.Exceptions.Infrastructure;

namespace PersonnelInfo.Application.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeServices(IEmployeeRepository repository,IStartLeaveHistoryRepository startLeaveHistoryRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);
        if (!entityList.Any()) throw new NotFoundEntity(typeof(Employee));
        var a= entityList.Select(e => Mapper.MapToDto(e, new EmployeeDto())).ToList();
        return a;
    }

    public async Task<bool> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
    {
        var existedEntity = await _repository.NationalIdExistAsync(addDto.NationalId, cancellationToken);
        if (existedEntity == null)
        {
            var entity = Mapper.MapToEntity(addDto, new Employee());
            entity.PersonnelCode = await _repository.MaxPersonnelCodeAsync(cancellationToken) + 1;

            await _unitOfWork.ExecuteInTransactionAsync(async _ =>
            {
                await _repository.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync();

                var startLeaveHistory = new StartLeaveHistory();
                entity.StartLeftHistories.Add(startLeaveHistory);
            }, cancellationToken);

            if (await _repository.NationalIdExistAsync(addDto.NationalId, cancellationToken) != null) return true;

            else throw new EntityAdditionFailedException($"Failed to add the {typeof(Employee).Name} due to an unknown reason.");
        }
        throw new DuplicateEntityException($"An {typeof(Employee).Name} with the same NationalId already exists.");
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(Employee));

        var relatedEntities = PreChangeProcedures.GetRelatedEntityCounts(entity);
        if (relatedEntities.Any())
        {
            var message = $"Cannot delete employee with related records: " + string.Join(", ", relatedEntities.Select(re => $"{re.Key}: {re.Value}"));
            throw new InvalidOperationException(message);
        }

        await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        {
            await _repository.DeleteAsync(entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task<EmployeeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundEntity();
        return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task<EmployeeDto> GetByNationalId(string nationalId, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.NationalIdExistAsync(nationalId, cancellationToken)
            ?? throw new NotFoundEntity();
        return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(updateDto.Id, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(Employee));

        Mapper.MapToEntity(updateDto, entity);

        await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }, cancellationToken);
    }
}
