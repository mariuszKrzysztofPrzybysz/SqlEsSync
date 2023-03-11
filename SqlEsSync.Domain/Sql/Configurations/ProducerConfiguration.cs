using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Sql.Configurations;

public sealed class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder
            .ToTable("Producers", tb => tb.IsTemporal());

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .UseIdentityColumn();

        builder
            .Property(e => e.Name)
            .IsUnicode()
            .IsRequired();
    }
}
