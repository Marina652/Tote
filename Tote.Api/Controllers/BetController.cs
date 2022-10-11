using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Bet.Commands.CreateBet;
using Tote.Application.Bet.Commands.DeleteBet;
using Tote.Application.Bet.Commands.UpdateBet;
using Tote.Application.Bet.Common.Models;
using Tote.Application.Bet.Queries.GetBetById;
using Tote.Contracts;
using Tote.Contracts.Bet.Requests;
using Tote.Contracts.Bet.Responses;

namespace Tote.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BetController : ControllerBase
{
    private readonly IMediator _mediator;

    public BetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var foundBet = await _mediator.Send(
            new GetBetByIdQuery(id),
            token);

        var response = foundBet.Adapt<GetBetByIdResponce>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBetRequest request,
        CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateBetCommand(request.Adapt<Bet>()),
            token);

        var response = new CreateBetResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(BetController.Get),
           new { response.Id },
           response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBetStatus([FromRoute] Guid id, [FromBody] UpdateBetRequest request,
        CancellationToken token)
    {
        await _mediator.Send(
            new UpdateBetStatusCommand(id, request.Status),
            token);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteBetCommand(id),
            token);

        return Ok();
    }
}
