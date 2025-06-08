using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository 
{
    public async Task AddAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        entity.BirthPlaceId = 32;
        entity.DepartmentId = "فروش";
        entity.ShenasnameIssuedPlaceId = 32;

        await _dbSet.AddAsync(entity, cancellationToken);
    }
}