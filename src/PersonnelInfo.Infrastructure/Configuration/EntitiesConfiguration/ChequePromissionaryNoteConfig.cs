using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class ChequePromissionaryNoteConfig : IEntityTypeConfiguration<ChequePromissionaryNote>
{
    void IEntityTypeConfiguration<ChequePromissionaryNote>.Configure(EntityTypeBuilder<ChequePromissionaryNote> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "ChequePromissionaryNotes");
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Type).HasConversion(c => _Conversions.NoteType2String(c), c => _Conversions.String2NoteType(c));
    }
}

