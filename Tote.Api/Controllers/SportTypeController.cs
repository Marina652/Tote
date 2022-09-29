using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.SportType.Commands.CreateSportType;
using Tote.Application.SportType.Commands.DeleteSportType;
using Tote.Application.SportType.Commands.UpdatesportType;
using Tote.Application.SportType.Common;
using Tote.Application.SportType.Queries.GetSportTypeById;

namespace Tote.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SportTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id,
          CancellationToken token)
        {
            var foundEvent = await _mediator.Send(
                new GetSportTypeByIdQuery(id),
                token);

            return Ok(foundEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SportType sportType,
           CancellationToken token)
        {
            var createdGuid = await _mediator.Send(
                new CreateSportTypeCommand(sportType),
                token);

            return Ok(createdGuid);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(SportType newSportType,
         CancellationToken token)
        {
            await _mediator.Send(
                new UpdateSportTypeCommand(newSportType),
                token);

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken token)
        {
            await _mediator.Send(
                new DeleteSportTypeCommand(id),
                token);

            return Ok();
        }
    }
}
