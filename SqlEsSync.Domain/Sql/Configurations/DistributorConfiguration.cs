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
            .Ignore(e => e.VersionPeriodEnd);

        builder
            .Ignore(e => e.VersionPeriodStart);
    }
}
