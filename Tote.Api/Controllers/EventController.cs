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
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.EventRoutes.GetEventById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var foundEvent = await _mediator.Send(
            new GetEventByIdQuery(id),
            token);

        var response = foundEvent.Adapt<GetEventByIdResponse>();

        return Ok(response);
    }

    [HttpPost(ApiRoutes.EventRoutes.CreateEvent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    [HttpPatch(ApiRoutes.EventRoutes.UpdateEvent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventRequest request,
        CancellationToken token)
    {
        var newEvent = request.Adapt<Event>();
        newEvent.Id = id;

        await _mediator.Send(
            new UpdateEventCommand(newEvent),
            token);

        return Ok();
    }

    [HttpDelete(ApiRoutes.EventRoutes.DeleteEvent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteEventCommand(id),
            token);

        return Ok();
    }
}