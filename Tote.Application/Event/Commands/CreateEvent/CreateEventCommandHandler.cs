﻿using MediatR;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Commands.CreateEvent
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventWriter _eventWriter;

        public CreateEventCommandHandler(IEventWriter eventWriter)
        {
            _eventWriter = eventWriter;
        }

        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await _eventWriter.WriteAsync(request.NewEvent, cancellationToken);
            return Unit.Value;
        }
    }
}
