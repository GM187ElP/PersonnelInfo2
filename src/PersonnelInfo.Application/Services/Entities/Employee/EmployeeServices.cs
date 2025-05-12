using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Infrastructure;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Application;

namespace PersonnelInfo.Application.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeServices(IEmployeeRepository repository, IStartLeaveHistoryRepository startLeaveHistoryRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }


    public async Task<CrudOperationResult> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
    {
        var existedEntity = await _repository.NationalIdExistAsync(addDto.NationalId, cancellationToken);

        if (existedEntity)
        {
            return new CrudOperationResult
            {
                Success = false,
                AffectedRows = 0,
                ErrorMessage = $"An entity with name {typeof(Employee).Name} with the same NationalId already exists."
            };
        }
        else
        {
            var entity = Mapper.MapToEntity(addDto, new Employee());
            entity.PersonnelCode = await _repository.MaxPersonnelCodeAsync(cancellationToken) + 1;

            entity.StartLeftHistories.Add(new StartLeaveHistory());

            int affected = 0;
            await _unitOfWork.ExecuteInTransactionAsync(async _ =>
            {
                await _repository.AddAsync(entity, cancellationToken);
                affected = await _unitOfWork.SaveChangesAsync(cancellationToken);
            }, cancellationToken);

            return new CrudOperationResult
            {
                Success = affected > 0,
                AffectedRows = affected,
                EntityId = entity.Id,
            };
        }
    }

    public async Task<CrudOperationResult> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return new CrudOperationResult
            {
                Success = false,
                ErrorMessage = $"No employee found with ID: {id}."
            };

        return new CrudOperationResult
        {
            Success = true,
            Data = Mapper.MapToDto(entity, new EmployeeDto())
        };
    }

    public async Task<List<EmployeeDto>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);


        var a = entityList.Select(e => Mapper.MapToDto(e, new EmployeeDto())).ToList();
        return a;
    }


    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new Exception();
        //var entity = await _repository.GetByIdAsync(id, cancellationToken)
        //              ?? throw new NotFoundEntity(typeof(Employee));

        //var relatedEntities = PreChangeProcedures.GetRelatedEntityCounts(entity);
        //if (relatedEntities.Any())
        //{
        //    var message = $"Cannot delete employee with related records: " + string.Join(", ", relatedEntities.Select(re => $"{re.Key}: {re.Value}"));
        //    throw new InvalidOperationException(message);
        //}

        //await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        //{
        //    await _repository.DeleteAsync(entity, cancellationToken);
        //}, cancellationToken);
    }


    public async Task<EmployeeDto> GetByNationalId(string nationalId, CancellationToken cancellationToken = default)
    {
        throw new Exception();
        //var entity = await _repository.NationalIdExistAsync(nationalId, cancellationToken)
        //    ?? throw new NotFoundEntity();
        //return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default)
    {
        throw new Exception();
        //var entity = await _repository.GetByIdAsync(updateDto.Id, cancellationToken)
        //              ?? throw new NotFoundEntity(typeof(Employee));

        //Mapper.MapToEntity(updateDto, entity);

        //await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        //{
        //    await _repository.UpdateAsync(entity, cancellationToken);
        //}, cancellationToken);
    }
}
