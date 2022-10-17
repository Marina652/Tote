using AutoMapper;
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
    [ApiController]
    public class OutcomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OutcomeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Outcomes.GetOutcomeById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id,
          CancellationToken token)
        {
            var foundOutcome = await _mediator.Send(
                new GetOutcomeByIdQuery(id),
                token);

            var response = _mapper.Map<GetOutcomeByIdResponse>(foundOutcome);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Outcomes.CreateOutcome)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateOutcomeRequest request,
           CancellationToken token)
        {
            var createdId = await _mediator.Send(
                new CreateOutcomeCommand(_mapper.Map<Outcome>(request)),
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOutcomeRequest request,
         CancellationToken token)
        {
            var newOutcome = _mapper.Map<Outcome>(request);
            newOutcome.Id = id;

            await _mediator.Send(
                new UpdateOutcomeCommand(newOutcome),
                token);

            return Ok();
        }


        [HttpDelete(ApiRoutes.Outcomes.DeleteOutcome)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
