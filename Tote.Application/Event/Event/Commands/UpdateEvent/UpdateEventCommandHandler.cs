using MediatR;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Application.Event.Commands.UpdateEvent;

internal class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IEventWriter _eventWriter;

    public UpdateEventCommandHandler(IEventWriter eventWriter)
    {
        _eventWriter = eventWriter;
    }

    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        await _eventWriter.UpdateAsync(request.NewEvent, cancellationToken);
        return Unit.Value;
    }
}
