using PersonnelInfo.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IEmployeeRepository
{
    Task AddAsync(Employee entity, CancellationToken cancellationToken = default);
    Task<PagedResult<Employee>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Employee?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<Employee?> GetByPersonnelCodeAsync(int personnelCode, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<int> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default);
    Task<bool> NationalIdExistAsync(string nationbalId, CancellationToken cancellationToken = default);

    Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default);
}

public class PagedResult<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
}