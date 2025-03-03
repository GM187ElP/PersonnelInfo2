using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Infrastructure;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Data.Seeders;

var dbContext = new DatabaseContext();


//dbContext.Database.EnsureDeleted();
//dbContext.Database.EnsureCreated();


//var jobt = new JobTitleSeeder(dbContext);
//var citySeeder = new CitySeeder(dbContext);

//await jobt.SeedJobTitlesFromJson();
//await citySeeder.SeedCitiesFromJson();

//Console.WriteLine("Cities have been seeded successfully.");

//EntityConstraintsInspector.PrintEntityConstraints(dbContext, typeof(Employee));

