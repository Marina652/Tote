using MediatR;
using AppEvent = Tote.Application.Event.Common.Models.Event;

namespace Tote.Application.Event.Commands.UpdateEvent;

public record UpdateEventCommand(AppEvent NewEvent) : IRequest;
