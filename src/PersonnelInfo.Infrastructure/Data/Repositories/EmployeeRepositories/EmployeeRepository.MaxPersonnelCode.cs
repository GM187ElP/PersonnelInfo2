using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository
{
        public async Task<int> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _dbSet
            .Where(e => e.PersonnelCode < 20000)
            .Select(e => e.PersonnelCode)
            .ToListAsync(cancellationToken);

        return employees
             .DefaultIfEmpty(0)
             .Max();
    }
}

