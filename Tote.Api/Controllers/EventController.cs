using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Event.Commands.CreateEvent;
using Tote.Application.Event.Commands.DeleteEvent;
using Tote.Application.Event.Commands.UpdateEvent;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Queries.GetEventById;
using Mapster;
using Tote.Contracts.Event.Event.Responses;
using Tote.Contracts.Event.Event.Requests;

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

    [HttpGet]
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
        var createdGuid = await _mediator.Send(
            new CreateEventCommand(request.Adapt<Event>()),
            token);

        var response = new CreateEventResponse
        {
            Id = createdGuid
        };

        return Ok(response);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateEventRequest request,
        CancellationToken token)
    {
        await _mediator.Send(
            new UpdateEventCommand(request.Adapt<Event>()),
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