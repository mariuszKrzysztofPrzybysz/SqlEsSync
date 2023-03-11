using System.ComponentModel.DataAnnotations.Schema;

namespace SqlEsSync.Domain.Sql.Entities;

public sealed class Distributor
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;

    public DateTimeOffset VersionPeriodEnd { get; set; }

    public DateTimeOffset VersionPeriodStart { get; set; }
}
