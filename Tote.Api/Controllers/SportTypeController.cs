using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tote.Application.SportType.Commands.DeleteSportType;
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
