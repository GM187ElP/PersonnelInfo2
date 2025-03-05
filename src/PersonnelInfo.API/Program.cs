using Autofac;
using Autofac.Extensions.DependencyInjection;
using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Infrastructure.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddTransient<CitySeeder>();
builder.Services.AddTransient<JobTitleSeeder>();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ProjectModule()); 
});

builder.Services.AddOpenApi();

builder.Services.AddLogging();
builder.Services.AddAuthentication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonnelInfo");
    });

    app.MapOpenApi(); 
}

app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


//#region infrastructure methods
//await using var scope = app.Services.CreateAsyncScope();
//var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
//await databaseContext.Database.EnsureDeletedAsync();
//await databaseContext.Database.EnsureCreatedAsync();
//var citySeeder = scope.ServiceProvider.GetRequiredService<CitySeeder>();
//var jobTitleSeeder = scope.ServiceProvider.GetRequiredService<JobTitleSeeder>();
//await citySeeder.SeedCitiesFromJson();
//await jobTitleSeeder.SeedJobTitlesFromJson();
//#endregion



app.Run();
