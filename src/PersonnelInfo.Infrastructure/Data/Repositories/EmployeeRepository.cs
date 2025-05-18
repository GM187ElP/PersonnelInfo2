using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Infrastructure;
using System.Linq;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DbSet<Employee> _dbSet;
    private readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();
    }

    public async Task AddAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        entity.BirthPlaceId = 32;
        entity.DepartmentId = "فروش";
        entity.ShenasnameIssuedPlaceId = 32;

        await _dbSet.AddAsync(entity, cancellationToken);
    }

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

    public async Task<PagedResult<Employee>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
    new PagedResult<Employee>
    {
        TotalCount = await _dbSet.CountAsync(cancellationToken),
        Items = await _dbSet
            .AsNoTracking()
            .Where(e => !e.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
    };



    public async Task<bool> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default) =>
         await _dbSet.AnyAsync(e => e.NationalId == nationalId);

    public async Task<Employee?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => (e.IsDeleted == false && e.Id == id), cancellationToken);

    public async Task<Employee?> GetByPersonnelCodeAsync(int personnelCode, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => (e.IsDeleted == false && e.PersonnelCode == personnelCode), cancellationToken);

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


    public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}

