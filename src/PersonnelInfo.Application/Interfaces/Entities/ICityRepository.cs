using PersonnelInfo.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces.Entities;

public interface ICityRepository
{
    Task<Dictionary<string, IEnumerable<string>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<City?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}
