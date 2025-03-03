using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
{
    void IEntityTypeConfiguration<BankAccount>.Configure(EntityTypeBuilder<BankAccount> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder,"BankAccounts");
        builder.Property(x => x.AccountNumber).HasMaxLength(21);
        builder.Property(x => x.Iban).HasMaxLength(22).IsRequired();
    }
}


