using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;

namespace PersonnelInfo.Infrastructure.Configuration;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DatabaseContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder connectionString = new()
        {
            DataSource = ".",
            InitialCatalog = "PersonnelInfoDb",
            IntegratedSecurity = true,
            MultipleActiveResultSets = true,
            TrustServerCertificate = true,
        };

        optionsBuilder.UseSqlServer(connectionString.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);
    }
}
