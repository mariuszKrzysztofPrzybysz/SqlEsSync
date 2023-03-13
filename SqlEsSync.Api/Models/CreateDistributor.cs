namespace SqlEsSync.Api.Models
{
    public record CreateDistributor(string Name, string AddressLine1, string? AddressLine2, long Regon, string Phone, string Email)
    {
    }
}
