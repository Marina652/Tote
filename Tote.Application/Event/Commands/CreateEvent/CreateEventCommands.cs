using MediatR;

namespace Tote.Application.Event.Commands.CreateEvent
{
    public record CreateEventCommand(Common.Event NewEvent) : IRequest;
}
