﻿using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Market.Commands.CreateMarket;
using Tote.Application.Market.Commands.DeleteMarket;
using Tote.Application.Market.Commands.UpdateMarket;
using Tote.Application.Market.Common.Models;
using Tote.Application.Market.Queries.GetMarketById;
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

    [HttpGet]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundMarket = await _mediator.Send(
            new GetMarketByIdQuery(id),
            token);

        var response = foundMarket.Adapt<GetMarketByIdResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMarketRequest request,
       CancellationToken token)
    {
        var createdGuid = await _mediator.Send(
            new CreateMarketCommand(request.Adapt<Market>()),
            token);

        var response = new CreateMarketResponse
        {
            Id = createdGuid
        };

        return Ok(response);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateMarketRequest request,
     CancellationToken token)
    {
        await _mediator.Send(
            new UpdateMarketCommand(request.Adapt<Market>()),
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
