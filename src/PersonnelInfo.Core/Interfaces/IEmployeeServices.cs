using PersonnelInfo.Core.DTOs.Entities.Employees;

namespace PersonnelInfo.Core.Interfaces;

public interface IEmployeeServices
{
    Task<bool> AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default);
    Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetByNationalId(string nationalId, CancellationToken cancellationToken = default);
}
