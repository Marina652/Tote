using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.Outcome.Commands.CreateOutcome;
using Tote.Application.Outcome.Commands.DeleteOutcome;
using Tote.Application.Outcome.Commands.UpdateOutcome;
using Tote.Application.Outcome.Common.Models;
using Tote.Application.Outcome.Queries.GetOutcomeById;
using Tote.Contracts;
using Tote.Contracts.Outcome.Requests;
using Tote.Contracts.Outcome.Responses;

namespace Tote.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OutcomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OutcomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Outcomes.GetOutcomeById)]
        public async Task<IActionResult> Get(Guid id,
          CancellationToken token)
        {
            var foundOutcome = await _mediator.Send(
                new GetOutcomeByIdQuery(id),
                token);

            var response = foundOutcome.Adapt<GetOutcomeByIdResponse>();

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Outcomes.CreateOutcome)]
        public async Task<IActionResult> Create(CreateOutcomeRequest request,
           CancellationToken token)
        {
            var createdId = await _mediator.Send(
                new CreateOutcomeCommand(request.Adapt<Outcome>()),
                token);

            var response = new CreateOutcomeResponse
            {
                Id = createdId
            };

            return CreatedAtAction(nameof(OutcomeController.Get),
              new { response.Id },
              response);
        }

        [HttpPatch(ApiRoutes.Outcomes.UpdateOutcome)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOutcomeRequest request,
         CancellationToken token)
        {
            var newOutcome = request.Adapt<Outcome>();
            newOutcome.Id = id;

            await _mediator.Send(
                new UpdateOutcomeCommand(newOutcome),
                token);

            return Ok();
        }


        [HttpDelete(ApiRoutes.Outcomes.DeleteOutcome)]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken token)
        {
            await _mediator.Send(
                new DeleteOutcomeCommand(id),
                token);

            return Ok();
        }
    }
}
