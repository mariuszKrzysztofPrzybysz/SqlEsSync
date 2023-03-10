using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Interfaces;

public interface IDistributorRepository
{
    Task<long> CreateAsync(Distributor distributor, CancellationToken cancellationToken = default);

    Task<Distributor?> TryGetByIdAsync(long id, CancellationToken cancellationToken = default);
}
