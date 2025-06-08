namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository 
{
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            entity.PersonnelCode = await MaxPersonnelCodeAsync(cancellationToken) + 1;
            entity.IsDeleted = true;
            return true;
        }

        return false;
    }
}