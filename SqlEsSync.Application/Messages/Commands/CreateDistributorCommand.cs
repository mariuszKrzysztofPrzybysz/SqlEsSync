using MediatR;

namespace SqlEsSync.Application.Messages.Commands
{
    public record CreateDistributorCommand(string Name, string AddressLine1, string? AddressLine2, long Regon, string Phone, string Email)
        : IRequest<long>
    {
    }
}
