using MediatR;

namespace Tote.Application.Event.Commands.DeleteEvent;

public record DeleteEventCommand(Guid Id) : IRequest;
