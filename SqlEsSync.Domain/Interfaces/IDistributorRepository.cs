using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Domain.Interfaces;

public interface IDistributorRepository
{
    Task<Distributor?> TryGetByIdAsync(long id, CancellationToken cancellationToken = default);
}
