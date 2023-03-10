namespace SqlEsSync.Api.Models
{
    public class DistributorDetails
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public long Regon { get; set; }

        public string Phone { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}
