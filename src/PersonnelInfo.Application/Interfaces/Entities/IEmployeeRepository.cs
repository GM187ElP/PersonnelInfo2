using PersonnelInfo.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IEmployeeRepository
{
    Task AddAsync(Employee entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Employee entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default);
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Employee> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<long> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default);
    Task<Employee> NationalIdExistAsync(string nationbalId, CancellationToken cancellationToken = default);
}
