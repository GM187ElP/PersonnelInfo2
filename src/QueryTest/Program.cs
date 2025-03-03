


using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration;

var db = new DatabaseContext();

var _dbSet = db.Set<City>();

var dictionary = await _dbSet.AsNoTracking()
    .Where(c => c.ProvinceId != null)
    .GroupBy(c => c.ProvinceId)
    .ToDictionaryAsync(
        g => _dbSet.AsNoTracking().First(p => p.Id == g.Key).Name, 
        g => g.Select(c => c.Name).ToList() 
    );



Console.ReadLine();

