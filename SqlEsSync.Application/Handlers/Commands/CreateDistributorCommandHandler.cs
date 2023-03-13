using MediatR;
using SqlEsSync.Application.Messages.Commands;
using SqlEsSync.Domain.Interfaces;
using SqlEsSync.Domain.Sql.Entities;

namespace SqlEsSync.Application.Handlers.Commands
{
    public sealed class CreateDistributorCommandHandler : IRequestHandler<CreateDistributorCommand, long>
    {
        private readonly IDistributorRepository _repository;

        public CreateDistributorCommandHandler(IDistributorRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(CreateDistributorCommand request, CancellationToken cancellationToken)
        {
            var distributor = new Distributor
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                Regon = request.Regon
            };

            distributor = await _repository.CreateAsync(distributor, cancellationToken);

            return distributor.Id;
        }
    }
}
