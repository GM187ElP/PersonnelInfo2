using PersonnelInfo.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IJobTitleRepository
{
    Task AddAsync(JobTitle entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateAsync(JobTitle entity, CancellationToken cancellationToken = default);
    Task<List<JobTitle>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<JobTitle> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}
