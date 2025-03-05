using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        var dateDelimiter = '-';
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Employees");
        builder.HasIndex(e => e.PersonnelCode).IsUnique();
        builder.HasIndex(e => e.NationalId).IsUnique();
        builder.HasIndex(e => e.ContactNumber).IsUnique();

        builder.Property(e => e.NationalId).IsRequired().HasMaxLength(10);
        builder.Property(e => e.ContactNumber).IsRequired().HasMaxLength(11);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(21);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(21);

        builder.Property(e => e.FatherName).HasMaxLength(21);
        builder.Property(e => e.ShenasnameNumber).HasMaxLength(10);
        builder.Property(e => e.ShenasnameSerial).HasMaxLength(2);
        builder.Property(e => e.ShenasnameSerie).HasMaxLength(6);
        builder.Property(e => e.ShenasnameSerialLetter).HasMaxLength(3);
        builder.Property(e => e.InsurranceCode).HasMaxLength(8);
        builder.Property(e => e.InsurranceStatus).HasMaxLength(21);
        builder.Property(e => e.InternalContactNumber).HasMaxLength(3);
        builder.Property(e => e.LandPhoneNumber).HasMaxLength(11);
        builder.Property(e => e.PostalCode).HasMaxLength(10);
        builder.Property(e => e.MostRecentDegree).HasMaxLength(21);
        builder.Property(e => e.Major).HasMaxLength(21);

        builder.HasOne(e => e.SuperVisor).WithMany(e => e.Employees).HasForeignKey(e => e.SupervisorId).OnDelete(DeleteBehavior.Restrict); ;

        builder.HasMany(e => e.ChequePromissionaryNotes).WithOne(c => c.Employee).HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(e => e.StartLeftHistories).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(e => e.BankAccounts).WithOne(b => b.Employee).HasForeignKey(b => b.EmployeeId).OnDelete(DeleteBehavior.Restrict);

        #region Conversions
        builder.Property(e => e.GenderDisplay).HasConversion(e => _Conversions.GenderType2String(e), e => _Conversions.String2GenderType(e));
        builder.Property(e => e.WorkingStatusDisplay).HasConversion(e => _Conversions.WorkingStatus2String(e), e => _Conversions.String2WorkingStatus(e));

    //    builder.Property(e => e.BirthDate).HasConversion(e => _Conversions.Gregorian2Farsi(e, dateDelimiter),
    //e => string.IsNullOrEmpty(e) ? throw new Exception("Invalid BirthDate") : _Conversions.Farsi2Gregorian(e, dateDelimiter));

    //    builder.Property(e => e.StartingDate).HasConversion(e => _Conversions.Gregorian2Farsi(e, dateDelimiter),
    //        e => string.IsNullOrEmpty(e) ? throw new Exception("Invalid StartingDate") : _Conversions.Farsi2Gregorian(e, dateDelimiter));

    //    builder.Property(e => e.LeavingDate).HasConversion(e => e.HasValue ? _Conversions.Gregorian2Farsi(e.Value, dateDelimiter) : null,
    //        e => string.IsNullOrEmpty(e) ? null : _Conversions.Farsi2Gregorian(e, dateDelimiter));



        #endregion
    }
}
















