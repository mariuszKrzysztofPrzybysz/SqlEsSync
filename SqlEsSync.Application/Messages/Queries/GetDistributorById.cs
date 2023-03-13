using MediatR;
using SqlEsSync.Infrastructure.Models;

namespace SqlEsSync.Application.Messages.Queries;

public record GetDistributorById(long Id) : IRequest<DistributorDetails?>
{
}