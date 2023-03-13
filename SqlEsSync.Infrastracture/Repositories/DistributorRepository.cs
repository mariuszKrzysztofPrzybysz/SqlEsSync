using Microsoft.EntityFrameworkCore;
using SqlEsSync.Domain.Interfaces;
using SqlEsSync.Domain.Sql;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Infrastructure.Repositories
{
    public sealed class DistributorRepository : IDistributorRepository
    {
        public const string PeriodEnd = "PeriodEnd";
        public const string PeriodStart = "PeriodStart";

        private readonly SqlEsSyncContext _context;

        public DistributorRepository(SqlEsSyncContext context)
        {
            _context = context;
        }

        public async Task<Distributor> CreateAsync(Distributor distributor, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Distributors.AddAsync(distributor, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Entity;
        }

        public async Task<Distributor?> TryGetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entityWithPeriod = await _context.Distributors
                .TemporalAsOf(DateTime.UtcNow)
                .Where(p => p.Id == id)
                .Select(d => new
                {
                    Distributor = d,
                    PeriodStart = EF.Property<DateTime>(d, PeriodStart),
                    PeriodEnd = EF.Property<DateTime>(d, PeriodEnd)
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entityWithPeriod is null)
            {
                return null;
            }

            entityWithPeriod.Distributor.VersionPeriodEnd = DateTime.SpecifyKind(entityWithPeriod.PeriodEnd, DateTimeKind.Utc);
            entityWithPeriod.Distributor.VersionPeriodStart = DateTime.SpecifyKind(entityWithPeriod.PeriodStart, DateTimeKind.Utc);

            return entityWithPeriod.Distributor;
        }
    }
}
