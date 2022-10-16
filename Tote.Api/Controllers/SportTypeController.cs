using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.SportType.Commands.CreateSportType;
using Tote.Application.SportType.Commands.DeleteSportType;
using Tote.Application.SportType.Commands.UpdateSportType;
using Tote.Application.SportType.Common.Models;
using Tote.Application.SportType.Queries.GetSportTypeById;
using Tote.Contracts;
using Tote.Contracts.Event.SportType.Requests;
using Tote.Contracts.Event.SportType.Responses;

namespace Tote.Api.Controllers;

[ApiController]
public class SportTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public SportTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.SportTypes.GetSportTypeById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id,
      CancellationToken token)
    {
        var foundSportType = await _mediator.Send(
            new GetSportTypeByIdQuery(id),
            token);

        var response = foundSportType.Adapt<GetSportTypeByIdResponse>();

        return Ok(response);
    }

    [HttpPost(ApiRoutes.SportTypes.CreatesportType)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateSportTypeRequest request,
       CancellationToken token)
    {
        var createdId = await _mediator.Send(
            new CreateSportTypeCommand(request.Adapt<SportType>()),
            token);

        var response = new CreateSportTypeResponse
        {
            Id = createdId
        };

        return CreatedAtAction(nameof(SportTypeController.Get),
          new { response.Id },
          response);
    }

    [HttpPatch(ApiRoutes.SportTypes.UpdateSportType)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSportTypeRequest request,
     CancellationToken token)
    {
        var newSportType = request.Adapt<SportType>();
        newSportType.Id = id;

        await _mediator.Send(
            new UpdateSportTypeCommand(newSportType),
            token);

        return Ok();
    }


    [HttpDelete(ApiRoutes.SportTypes.DeleteSportType)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteSportTypeCommand(id),
            token);

        return Ok();
    }
}
