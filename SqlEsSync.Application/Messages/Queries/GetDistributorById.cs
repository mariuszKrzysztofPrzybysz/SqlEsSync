using MediatR;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Application.Messages.Queries;

public record GetDistributorById(long Id) : IRequest<Distributor?>
{
}