using PersonnelInfo.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IBankNameRepository
{
    Task AddAsync(BankName entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateAsync(BankName entity, CancellationToken cancellationToken = default);
    Task<List<BankName>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BankName> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}
