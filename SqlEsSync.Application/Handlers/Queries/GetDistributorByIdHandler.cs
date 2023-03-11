using MediatR;
using SqlEsSync.Application.Messages.Queries;
using SqlEsSync.Domain.Interfaces;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Application.Handlers.Queries
{
    public sealed class GetDistributorByIdHandler : IRequestHandler<GetDistributorById, Distributor?>
    {
        private readonly IDistributorRepository _repository;

        public GetDistributorByIdHandler(IDistributorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Distributor?> Handle(GetDistributorById request, CancellationToken cancellationToken)
        {
            var distributor = await _repository.TryGetByIdAsync(request.Id, cancellationToken);

            return distributor;
        }
    }
}
