using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Sql.Configurations
{
    public sealed class SyncStatusConfiguration : IEntityTypeConfiguration<SyncStatus>
    {
        public void Configure(EntityTypeBuilder<SyncStatus> builder)
        {
            builder
                .ToTable("SyncStatuses", tb => tb.IsTemporal());

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Code)
                .HasMaxLength(25)
                .IsRequired();

            builder
                .HasIndex(e => e.Code)
                .IsUnique();

            builder
                .Property(e => e.TranslationKey)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .HasIndex(e => e.TranslationKey)
                .IsUnique();
        }
    }
}
