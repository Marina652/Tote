using MediatR;
using AppEvent = Tote.Application.Event.Common.Models.Event;

namespace Tote.Application.Event.Commands.CreateEvent;

public record CreateEventCommand(AppEvent NewEvent) : IRequest<Guid>;
