using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;
using Tote.Application.OutcomeBlock.Common.Models;
using Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;
using Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockMarkets;
using Tote.Contracts;
using Tote.Contracts.OutcomeBlock.Requests;
using Tote.Contracts.OutcomeBlock.Responses;

namespace Tote.Api.Controllers;

[ApiController]
public class OutcomeBlockController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OutcomeBlockController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.OutcomeBlocks.GetOutcomeBlockById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundOutcomeBlock = await _mediator.Send(
            new GetOutcomeBlockByIdQuery(id),
            token);

        var response = _mapper.Map<GetOutcomeBlockByIdResponse>(foundOutcomeBlock);

        return Ok(response);
    }

    [HttpGet(ApiRoutes.OutcomeBlocks.GetOutcomeBlockMarkets)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMarkets(Guid id,
    CancellationToken token)
    {
        var response = await _mediator.Send(
            new GetOutcomeBlockMarketsQuery(id),
            token);

        return Ok(response);
    }

    [HttpPost(ApiRoutes.OutcomeBlocks.CreateOutcomeBlock)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateOutcomeBlockRequest request,
       CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateOutcomeBlockCommand(_mapper.Map<OutcomeBlock>(request)),
            token);

        var response = new CreateOutcomeBlockResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(OutcomeBlockController.Get),
          new { response.Id },
          response);
    }

    [HttpPatch(ApiRoutes.OutcomeBlocks.UpdateOutcomeBlock)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOutcomeBlockRequest request,
     CancellationToken token)
    {
        var newOutcomeBlock = _mapper.Map<OutcomeBlock>(request);
        newOutcomeBlock.Id = id;

        await _mediator.Send(
            new UpdateOutcomeBlockCommand(newOutcomeBlock),
            token);

        return Ok();
    }


    [HttpDelete(ApiRoutes.OutcomeBlocks.DeleteOutcomeBlock)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteOutcomeBlockCommand(id),
            token);

        return Ok();
    }
}
