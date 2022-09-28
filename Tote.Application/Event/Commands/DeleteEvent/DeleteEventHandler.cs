using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Commands.DeleteEvent
{
    internal class DeleteEventHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRemover _eventRemover;

        public DeleteEventHandler(IEventRemover eventRemover)
        {
            _eventRemover = eventRemover;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await _eventRemover.RemoveByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
