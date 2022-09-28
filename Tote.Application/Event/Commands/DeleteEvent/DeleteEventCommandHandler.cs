using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Commands.DeleteEvent
{
    internal class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventWriter _eventWriter;

        public DeleteEventCommandHandler(IEventWriter eventWriter)
        {
            _eventWriter = eventWriter;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await _eventWriter.RemoveByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
