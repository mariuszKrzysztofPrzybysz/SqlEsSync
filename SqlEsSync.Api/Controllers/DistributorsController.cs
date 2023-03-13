using MediatR;
using Microsoft.AspNetCore.Mvc;
using SqlEsSync.Api.Models;
using SqlEsSync.Application.Messages.Queries;

namespace SqlEsSync.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistributorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var query = new GetDistributorById(id);
            var distributor = await _mediator.Send(query, cancellationToken);

            if (distributor is null)
            {
                return NotFound();
            }

            var model = new DistributorDetails
            {
                Address = string.Join(" ", distributor.AddressLine1, distributor.AddressLine2),
                Email = distributor.Email,
                Id = distributor.Id,
                Name = distributor.Name,
                Phone = distributor.Phone,
                Regon = distributor.Regon
            };

            return Ok(model);
        }
    }
}
