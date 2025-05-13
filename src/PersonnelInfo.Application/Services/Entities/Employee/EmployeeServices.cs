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

    public async Task<CrudOperationResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
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
            EntityId = entity.Id,
            Data = Mapper.MapToDto(entity, new EmployeeDto())
        };
    }

    public async Task<CrudOperationResult> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default) =>
         new CrudOperationResult
         {
             Success = true,
             Data = await _repository.NationalIdExistAsync(nationalId, cancellationToken)
         };

    public async Task<CrudOperationResult> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteAsync(id, cancellationToken);
        return new CrudOperationResult
        {
            Success = result,
            Data = result,
            ErrorMessage = result ? string.Empty : $"No employee found with ID: {id}."
        };
    }

    public async Task<CrudOperationResult> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var pagedResult = await _repository.GetAllAsync(page, pageSize, cancellationToken);

        var dtoList = pagedResult.Items
            .Select(e => Mapper.MapToDto(e, new EmployeeDto()))
            .ToList();

        return new CrudOperationResult
        {
            Success = dtoList.Any(),
            ErrorMessage = dtoList.Any() ? string.Empty : "There are no employees on this page.",
            Data = dtoList,
            TotalCount = pagedResult.TotalCount
        };
    }



    public async Task<CrudOperationResult> UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default)
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
