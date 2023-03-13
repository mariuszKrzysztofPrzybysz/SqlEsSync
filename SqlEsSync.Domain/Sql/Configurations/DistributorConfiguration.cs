using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Sql.Configurations;

public sealed class DistributorConfiguration : IEntityTypeConfiguration<Distributor>
{
    public void Configure(EntityTypeBuilder<Distributor> builder)
    {
        builder
            .ToTable(name: "Distributors", tb => tb.IsTemporal());

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .UseIdentityColumn();

        builder
            .Property(e => e.Name)
            .IsUnicode()
            .IsRequired();

        builder
            .Property(e => e.AddressLine1)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(e => e.AddressLine2)
            .HasMaxLength(250);

        builder
            .Property(e => e.Regon)
            .IsRequired();

        builder
            .Property(e => e.Phone)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(e => e.Email)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Ignore(e => e.VersionPeriodEnd);

        builder
            .Ignore(e => e.VersionPeriodStart);
    }
}
