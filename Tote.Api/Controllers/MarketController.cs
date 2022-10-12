using Mapster;
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
[Route("[controller]")]
public class MarketController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundMarket = await _mediator.Send(
            new GetMarketByIdQuery(id),
            token);

        var response = foundMarket.Adapt<GetMarketByIdResponse>();

        return Ok(response);
    }

    [HttpGet(ApiRoutes.Markets.GetMarketOutcomes)]
    public async Task<IActionResult> GetMarketOutcomes(Guid id,
     CancellationToken token)
    {
        var response = await _mediator.Send(
            new GetMarketOutcomesQuery(id),
            token);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMarketRequest request,
       CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateMarketCommand(request.Adapt<Market>()),
            token);

        var response = new CreateMarketResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(MarketController.Get),
           new { response.Id },
           response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMarketRequest request,
     CancellationToken token)
    {
        var newMarket = request.Adapt<Market>();
        newMarket.Id = id;

        await _mediator.Send(
            new UpdateMarketCommand(newMarket),
            token);

        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteMarketCommand(id),
            token);

        return Ok();
    }
}
