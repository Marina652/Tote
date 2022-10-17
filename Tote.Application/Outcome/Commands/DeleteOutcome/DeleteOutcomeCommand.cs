using MediatR;

namespace Tote.Application.Outcome.Commands.DeleteOutcome;

public record DeleteOutcomeCommand(Guid Id) : IRequest;
