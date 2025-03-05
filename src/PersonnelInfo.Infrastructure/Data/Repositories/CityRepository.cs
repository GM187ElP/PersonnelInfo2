using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class CityRepository : ICityRepository
{
    private readonly DbSet<City> _dbSet;
    private readonly DbContext _context;

    public CityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<City>();
    }

    public async Task<Dictionary<string, IEnumerable<string>>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking()
            .Where(c => c.ProvinceId != 0)
            .GroupBy(c => c.ProvinceId)
            .Select(g =>
            new
            {
                ProvinceName = _dbSet.AsNoTracking().FirstOrDefault(c => c.Id == g.Key)!.Name,
                CityName = g.Select(x => x.Name)
            }).ToDictionaryAsync(g => g.ProvinceName, g => g.CityName, cancellationToken);

    public async Task<City?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}
