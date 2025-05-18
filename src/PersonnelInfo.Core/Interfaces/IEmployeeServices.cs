using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Infrastructure;

namespace PersonnelInfo.Core.Interfaces;

public interface IEmployeeServices
{
    Task<CrudDataResult<long>> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default);
    Task<CrudDataResult<EmployeeDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CrudListResult<EmployeeDto>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<CrudDataResult<bool>> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default);
}
