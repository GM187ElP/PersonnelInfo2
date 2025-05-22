using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;

namespace PersonnelInfo.Infrastructure.Configuration;
public class DatabaseContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid, 
    IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
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
        var identitySchema = "identity";
        modelBuilder.Entity<IdentityRole<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityUser<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityUserClaim<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityUserLogin<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityUserRole<Guid>>().Metadata.SetSchema(identitySchema);
        modelBuilder.Entity<IdentityUserToken<Guid>>().Metadata.SetSchema(identitySchema);

        modelBuilder.Entity<IdentityUserLogin<Guid>>()
        .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasKey(r => new { r.UserId, r.RoleId });

        modelBuilder.Entity<IdentityUserToken<Guid>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);
    }
}
