using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class JobTitleRepository : IJobTitleRepository
{
    private readonly DbSet<JobTitle> _dbSet;
    private readonly DbContext _context;

    public JobTitleRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<JobTitle>();
    }

    public async Task AddAsync(JobTitle entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        _dbSet.Remove(entity);
    }

    public async Task<List<JobTitle>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        return entities;
    }

    public async Task<JobTitle> GetByIdAsync(string id, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Title == id, cancellationToken);

    public async Task UpdateAsync(JobTitle entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Title }, cancellationToken);
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}
