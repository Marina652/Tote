using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Event.Commands.CreateEvent;
using Tote.Application.Event.Commands.DeleteEvent;
using Tote.Application.Event.Commands.UpdateEvent;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Queries.GetEventById;
using Tote.Contracts.Event.Responses;
using Tote.Contracts.Event.Requests;
using Tote.Contracts;
using AutoMapper;

namespace Tote.Api.Controllers;

[ApiController]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EventController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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

        var response = _mapper.Map<GetEventByIdResponse>(foundEvent);

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
            new CreateEventCommand(_mapper.Map<Event>(request)),
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
        var newEvent = _mapper.Map<Event>(request);
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