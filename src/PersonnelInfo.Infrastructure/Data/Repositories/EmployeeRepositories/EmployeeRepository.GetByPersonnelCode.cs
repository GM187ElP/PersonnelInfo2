using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository 
{
    public async Task<Employee?> GetByPersonnelCodeAsync(int personnelCode, CancellationToken cancellationToken = default) =>
    await _dbSet
        .AsNoTracking()
        .Include(e => e.ChequePromissionaryNotes)
        .Include(e => e.StartLeftHistories)
        .Include(e => e.BankAccounts)
        .FirstOrDefaultAsync(e => (e.IsDeleted == false && e.PersonnelCode == personnelCode), cancellationToken);
}