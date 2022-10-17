using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Market.Commands.CreateMarket;
using Tote.Application.Market.Commands.DeleteMarket;
using Tote.Application.Market.Commands.UpdateMarket;
using Tote.Application.Market.Common.Models;
using Tote.Application.Market.Queries.GetMarketById;
using Tote.Application.Market.Queries.GetMarketOutcomes;
using Tote.Contracts;
using Tote.Contracts.OutcomeBlock.Market.Requests;
using Tote.Contracts.OutcomeBlock.Market.Responses;

namespace Tote.Api.Controllers;

[ApiController]
public class MarketController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MarketController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.Markets.GetMarketById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundMarket = await _mediator.Send(
            new GetMarketByIdQuery(id),
            token);

        var response = _mapper.Map<GetMarketByIdResponse>(foundMarket);

        return Ok(response);
    }

    [HttpGet(ApiRoutes.Markets.GetMarketOutcomes)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMarketOutcomes(Guid id,
     CancellationToken token)
    {
        var response = await _mediator.Send(
            new GetMarketOutcomesQuery(id),
            token);

        return Ok(response);
    }

    [HttpPost(ApiRoutes.Markets.CreateMarket)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateMarketRequest request,
       CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateMarketCommand(_mapper.Map<Market>(request)),
            token);

        var response = new CreateMarketResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(MarketController.Get),
           new { response.Id },
           response);
    }

    [HttpPatch(ApiRoutes.Markets.UpdateMarket)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMarketRequest request,
     CancellationToken token)
    {
        var newMarket = _mapper.Map<Market>(request);
        newMarket.Id = id;

        await _mediator.Send(
            new UpdateMarketCommand(newMarket),
            token);

        return Ok();
    }


    [HttpDelete(ApiRoutes.Markets.DeleteMarket)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteMarketCommand(id),
            token);

        return Ok();
    }
}
