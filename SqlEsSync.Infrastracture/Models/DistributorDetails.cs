namespace SqlEsSync.Infrastructure.Models
{
    public class DistributorDetails
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;

        public string AddressLine1 { get; set; } = default!;

        public string? AddressLine2 { get; set; }

        public long Regon { get; set; }

        public string Phone { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}
