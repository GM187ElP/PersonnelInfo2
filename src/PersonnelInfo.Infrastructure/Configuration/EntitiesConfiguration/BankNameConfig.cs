using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class BankNameConfig : IEntityTypeConfiguration<BankName>
{
    void IEntityTypeConfiguration<BankName>.Configure(EntityTypeBuilder<BankName> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder,"BankNameList");
        builder.HasKey(x => x.Name);
    }
}
