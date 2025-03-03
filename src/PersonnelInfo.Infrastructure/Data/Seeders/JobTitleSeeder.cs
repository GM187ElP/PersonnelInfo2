using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Data.Seeders;
public class JobTitleSeeder
{
    private readonly DatabaseContext _context;
    public JobTitleSeeder(DatabaseContext context) => _context = context;

    public async Task SeedJobTitlesFromJson()
    {
        var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "src", "PersonnelInfo.Infrastructure", "Data", "Seeds", "JobTitles.json");
        var jsonData = await File.ReadAllTextAsync(filePath);
        var jobTitles = JsonSerializer.Deserialize<List<JobTitle>>(jsonData);
        foreach (var jobTitle in jobTitles)
        {
            await _context.AddAsync(jobTitle);
        }
       
        await _context.SaveChangesAsync();
    }
}


