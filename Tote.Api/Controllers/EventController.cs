using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Event.Commands.CreateEvent;
using Tote.Application.Event.Commands.DeleteEvent;
using Tote.Application.Event.Commands.UpdateEvent;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Queries.GetEventById;
using Mapster;
using Tote.Contracts.Event.Responses;
using Tote.Contracts.Event.Requests;
using Tote.Contracts;

namespace Tote.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var foundEvent = await _mediator.Send(
            new GetEventByIdQuery(id),
            token);

        var response = foundEvent.Adapt<GetEventByIdResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventRequest request,
        CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateEventCommand(request.Adapt<Event>()),
            token);

        var response = new CreateEventResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(EventController.Get),
            new { response.Id }, 
            response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] UpdateEventRequest request,
        CancellationToken token)
    {
        var newEvent = request.Adapt<Event>();
        newEvent.Id = id;

        await _mediator.Send(
            new UpdateEventCommand(newEvent),
            token);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteEventCommand(id),
            token);

        return Ok();
    }
}