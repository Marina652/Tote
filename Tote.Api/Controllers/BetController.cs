using AutoMapper;
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
public class BetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BetController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.Bets.GetBetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var foundBet = await _mediator.Send(
            new GetBetByIdQuery(id),
            token);

        var response = _mapper.Map<GetBetByIdResponce>(foundBet);

        return Ok(response);
    }

    [HttpPost(ApiRoutes.Bets.CreateBet)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateBetRequest request,
        CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateBetCommand(_mapper.Map<Bet>(request)),
            token);

        var response = new CreateBetResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(BetController.Get),
           new { response.Id },
           response);
    }

    [HttpPatch(ApiRoutes.Bets.UpdateBetStatus)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBetStatus([FromRoute] Guid id, [FromBody] UpdateBetRequest request,
        CancellationToken token)
    {
        await _mediator.Send(
            new UpdateBetStatusCommand(id, request.Status),
            token);

        return Ok();
    }

    [HttpDelete(ApiRoutes.Bets.DeleteBet)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteBetCommand(id),
            token);

        return Ok();
    }
}
