using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Event.Commands.CreateEvent;
using Tote.Application.Event.Commands.DeleteEvent;
using Tote.Application.Event.Common;
using Tote.Application.Event.Queries.GetEventById;

namespace Tote.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
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

        [HttpPost]
        public async Task<IActionResult> Create(Event newEvent,
            CancellationToken token)
        {
            await _mediator.Send(
                new CreateEventCommand(newEvent),
                token);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken token)
        {
            await _mediator.Send(
                new DeleteEventCommand(id),
                token);

            return Ok();
        }
    }
}