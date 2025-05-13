using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Infrastructure;

namespace PersonnelInfo.Core.Interfaces;

public interface IEmployeeServices
{
    Task<CrudOperationResult> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default);

    Task<CrudOperationResult> UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default);
}
