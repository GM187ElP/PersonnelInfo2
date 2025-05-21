using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
using PersonnelInfo.Infrastructure.Entities;

namespace PersonnelInfo.Infrastructure.Configuration;
public class DatabaseContext : IdentityDbContext<User,IdentityRole,Guid,IdentityUserClaim<Guid>,IdentityUserRole<Guid>,IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>,IdentityUserToken<Guid>>
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
