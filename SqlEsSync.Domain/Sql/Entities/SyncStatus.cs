namespace SqlEsSync.Domain.Sql.Entities
{
    public class SyncStatus
    {
        public int Id { get; set; }

        public string Code { get; set; } = default!;

        public string TranslationKey { get; set; } = default!;
    }
}
