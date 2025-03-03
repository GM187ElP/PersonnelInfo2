using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
internal class StartLeaveHistoryRepository : IStartLeaveHistoryRepository
{
    public Task AddAsync(StartLeaveHistory entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<StartLeaveHistory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<StartLeaveHistory> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(StartLeaveHistory entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
