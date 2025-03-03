using PersonnelInfo.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IStartLeaveHistoryRepository
{
    Task AddAsync(StartLeaveHistory entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateAsync(StartLeaveHistory entity, CancellationToken cancellationToken = default);
    Task<List<StartLeaveHistory>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<StartLeaveHistory> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}
