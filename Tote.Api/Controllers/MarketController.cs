using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Market.Commands.CreateMarket;
using Tote.Application.Market.Commands.DeleteMarket;
using Tote.Application.Market.Commands.UpdateMarket;
using Tote.Application.Market.Common.Models;
using Tote.Application.Market.Queries.GetMarketById;

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

    [HttpGet]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundMarket = await _mediator.Send(
            new GetMarketByIdQuery(id),
            token);

        return Ok(foundMarket);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Market market,
       CancellationToken token)
    {
        var createdGuid = await _mediator.Send(
            new CreateMarketCommand(market),
            token);

        return Ok(createdGuid);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(Market newMarket,
     CancellationToken token)
    {
        await _mediator.Send(
            new UpdateMarketCommand(newMarket),
            token);

        return Ok();
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteMarketCommand(id),
            token);

        return Ok();
    }
}
