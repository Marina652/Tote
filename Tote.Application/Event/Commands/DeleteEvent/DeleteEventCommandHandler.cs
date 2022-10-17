using MediatR;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Application.Event.Commands.DeleteEvent;

internal class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IEventWriter _eventWriter;
    private readonly IEventReader _eventReader;

    public DeleteEventCommandHandler(IEventWriter eventWriter, IEventReader eventReader)
    {
        _eventWriter = eventWriter;
        _eventReader = eventReader;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var foundEvent = await _eventReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundEvent is null)
        {
            throw new ArgumentException("Object doesn't exist");
        }

        await _eventWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
