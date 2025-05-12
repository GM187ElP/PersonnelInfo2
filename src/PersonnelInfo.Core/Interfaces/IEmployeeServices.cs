using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Infrastructure;

namespace PersonnelInfo.Core.Interfaces;

public interface IEmployeeServices
{
    Task<CrudOperationResult> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default);
    Task<List<EmployeeDto>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<CrudOperationResult> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetByNationalId(string nationalId, CancellationToken cancellationToken = default);
}
