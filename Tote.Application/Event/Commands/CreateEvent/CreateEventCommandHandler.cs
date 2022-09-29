using MediatR;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Commands.CreateEvent
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventWriter _eventWriter;

        public CreateEventCommandHandler(IEventWriter eventWriter)
        {
            _eventWriter = eventWriter;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await _eventWriter.WriteAsync(request.NewEvent, cancellationToken);
        }
    }
}
