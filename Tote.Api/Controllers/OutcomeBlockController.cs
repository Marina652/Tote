using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;
using Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;
using Tote.Application.OutcomeBlock.Common.Models;
using Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;

namespace Tote.Api.Controllers
{
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

            return Ok(foundOutcomeBlock);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OutcomeBlock outcomeBlock,
           CancellationToken token)
        {
            var createdGuid = await _mediator.Send(
                new CreateOutcomeBlockCommand(outcomeBlock),
                token);

            return Ok(createdGuid);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(OutcomeBlock newOutcomeBlock,
         CancellationToken token)
        {
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
}
