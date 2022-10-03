using MediatR;

namespace Tote.Application.Event.Commands.CreateEvent;

public record CreateEventCommand(Common.Models.Event NewEvent) : IRequest<Guid>;
