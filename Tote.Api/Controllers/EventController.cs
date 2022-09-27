using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Event.Queries.GetEventById;

namespace Tote.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Event : ControllerBase
    {
        private readonly IMediator _mediator;

        public Event(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id,
            CancellationToken token)
        {
            var foundEvent = await _mediator.Send(
                new GetEventByIdQuery(id),
                token);

            return Ok(foundEvent);
        }
    }
}