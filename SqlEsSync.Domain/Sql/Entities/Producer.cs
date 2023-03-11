namespace SqlEsSync.Domain.Sql.Entities;

public sealed class Producer
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;
}
