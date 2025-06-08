using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository 
{
    public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}

