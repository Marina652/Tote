using MediatR;

namespace Tote.Application.Event.Commands.UpdateEvent;

public record UpdateEventCommand(Common.Models.Event NewEvent) : IRequest;
