using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class StartLeaveHistoryConfig : IEntityTypeConfiguration<StartLeaveHistory>
{
    void IEntityTypeConfiguration<StartLeaveHistory>.Configure(EntityTypeBuilder<StartLeaveHistory> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder,"StartLeaveHistories");
    }
}
