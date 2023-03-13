using MediatR;
using SqlEsSync.Application.Messages.Queries;
using SqlEsSync.Domain.Interfaces;
using SqlEsSync.Infrastructure.Models;

namespace SqlEsSync.Application.Handlers.Queries
{
    public sealed class GetDistributorByIdHandler : IRequestHandler<GetDistributorById, DistributorDetails?>
    {
        private readonly IDistributorRepository _repository;

        public GetDistributorByIdHandler(IDistributorRepository repository)
        {
            _repository = repository;
        }

        public async Task<DistributorDetails?> Handle(GetDistributorById request, CancellationToken cancellationToken)
        {
            var distributor = await _repository.TryGetByIdAsync(request.Id, cancellationToken);

            if (distributor is null)
            {
                return null;
            }

            return new DistributorDetails
            {
                AddressLine1 = distributor.AddressLine1,
                AddressLine2 = distributor.AddressLine2,
                Email = distributor.Email,
                Id = distributor.Id,
                Name = distributor.Name,
                Phone = distributor.Phone,
                Regon = distributor.Regon
            };
        }
    }
}
