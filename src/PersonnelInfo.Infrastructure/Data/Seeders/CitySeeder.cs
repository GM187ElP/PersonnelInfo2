using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Data.Seeders;
public class CitySeeder
{
    private readonly DatabaseContext _context;
    public CitySeeder(DatabaseContext context) => _context = context;

    public async Task SeedCitiesFromJson()
    {
        var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "src", "PersonnelInfo.Infrastructure", "Data", "SeedData", "Cities.json");
        var jsonData = await File.ReadAllTextAsync(filePath);
        var cities = JsonSerializer.Deserialize<List<City>>(jsonData);
        foreach (var city in cities)
        {
            await _context.AddAsync(city);
        }

        await _context.SaveChangesAsync();
    }
}
