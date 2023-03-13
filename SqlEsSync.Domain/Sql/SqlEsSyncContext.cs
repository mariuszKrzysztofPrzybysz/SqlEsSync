using Microsoft.EntityFrameworkCore;
using SqlEsSync.Domain.Sql.Configurations;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Sql;

public sealed class SqlEsSyncContext : DbContext
{
    public SqlEsSyncContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Distributor> Distributors { get; set; }

    public DbSet<Producer> Producers { get; set; }

    public DbSet<SyncStatus> SyncStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DistributorConfiguration());
        modelBuilder.ApplyConfiguration(new ProducerConfiguration());
        modelBuilder.ApplyConfiguration(new SyncStatusConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
