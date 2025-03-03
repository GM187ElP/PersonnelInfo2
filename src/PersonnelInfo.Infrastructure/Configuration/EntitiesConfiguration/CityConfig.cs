using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class CityConfig : IEntityTypeConfiguration<City>
{
    void IEntityTypeConfiguration<City>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder,"Cities");
        builder.Property(x => x.Name).HasMaxLength(21).IsRequired();
        builder.HasMany(x => x.BirthPlaces).WithOne(x => x.BirthPlace).HasForeignKey(x=>x.BirthPlaceId);
        builder.HasMany(x => x.ShenasnameIssuedPlaces).WithOne(x => x.ShenasnameIssuedPlace).HasForeignKey(x=>x.ShenasnameIssuedPlaceId);
    }
}

