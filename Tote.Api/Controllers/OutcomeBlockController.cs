using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;
using Tote.Application.OutcomeBlock.Common.Models;
using Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;
using Tote.Contracts.OutcomeBlock.Requests;
using Tote.Contracts.OutcomeBlock.Responses;

namespace Tote.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OutcomeBlockController : ControllerBase
{
    private readonly IMediator _mediator;

    public OutcomeBlockController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundOutcomeBlock = await _mediator.Send(
            new GetOutcomeBlockByIdQuery(id),
            token);

        var response = foundOutcomeBlock.Adapt<GetOutcomeBlockByIdResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOutcomeBlockRequest request,
       CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateOutcomeBlockCommand(request.Adapt<OutcomeBlock>()),
            token);

        var response = new CreateOutcomeBlockResponse
        {
            Id = createdId
        };

        return Ok(response);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOutcomeBlockRequest request,
     CancellationToken token)
    {
        var newOutcomeBlock = request.Adapt<OutcomeBlock>();
        newOutcomeBlock.Id = id;

        await _mediator.Send(
            new UpdateOutcomeBlockCommand(newOutcomeBlock),
            token);

        return Ok();
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteOutcomeBlockCommand(id),
            token);

        return Ok();
    }
}
