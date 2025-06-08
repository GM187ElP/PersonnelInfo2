using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Infrastructure;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Application;

namespace PersonnelInfo.Application.Services.Entities.Employee;

public class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeServices(IEmployeeRepository repository, IStartLeaveHistoryRepository startLeaveHistoryRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }


    public async Task<CrudDataResult<long>> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
    {
        var existedEntity = await _repository.NationalIdExistAsync(addDto.NationalId, cancellationToken);

        if (existedEntity)
        {
            return new CrudDataResult<long>
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

            return new CrudDataResult<long>
            {
                Success = affected > 0,
                AffectedRows = affected,
                Data = entity.Id,
            };
        }
    }

    public async Task<CrudDataResult<EmployeeDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return new CrudDataResult<EmployeeDto>
            {
                Success = false,
                ErrorMessage = $"No employee found with ID: {id}."
            };

        return new CrudDataResult<EmployeeDto>
        {
            Success = true,
            Data = Mapper.MapToDto(entity, new EmployeeDto())
            
        };
    }

    public async Task<CrudDataResult<bool>> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default) =>
         new CrudDataResult<bool>
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
            ErrorMessage = result ? string.Empty : $"No employee found with ID: {id}."
        };
    }

    public async Task<CrudListResult<EmployeeDto>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var pagedResult = await _repository.GetAllAsync(page, pageSize, cancellationToken);

        var dtoList = pagedResult.Items
            .Select(e => Mapper.MapToDto(e, new EmployeeDto()))
            .ToList();

        return new CrudListResult<EmployeeDto>
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
    }
}
