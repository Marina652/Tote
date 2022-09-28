using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Commands.UpdateEvent
{
    internal class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventUpdater _eventUpdater;

        public UpdateEventCommandHandler(IEventUpdater eventUpdater)
        {
            _eventUpdater = eventUpdater;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            await _eventUpdater.UpdateAsync(request.NewEvent, cancellationToken);
            return Unit.Value;
        }
    }
}
