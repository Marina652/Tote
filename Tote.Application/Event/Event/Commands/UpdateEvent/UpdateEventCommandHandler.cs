using MediatR;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Application.Event.Commands.UpdateEvent;

internal class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IEventWriter _eventWriter;
    private readonly IEventReader _eventReader;

    public UpdateEventCommandHandler(IEventWriter eventWriter, IEventReader eventReader)
    {
        _eventWriter = eventWriter;
        _eventReader = eventReader;
    }

    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var foundEvent = await _eventReader.ReadByIdAsync(request.NewEvent.Id, cancellationToken);
        
        if (foundEvent is null)
            throw new ArgumentException("Object doesn't exist");

        await _eventWriter.UpdateAsync(request.NewEvent, cancellationToken);
        return Unit.Value;
    }
}
