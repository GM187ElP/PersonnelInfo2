using PersonnelInfo.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface IChequePromissionaryNote
{
    Task AddAsync(ChequePromissionaryNote entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(ChequePromissionaryNote entity, CancellationToken cancellationToken = default);
    Task<List<ChequePromissionaryNote>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ChequePromissionaryNote> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}
