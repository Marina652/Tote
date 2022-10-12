using MediatR;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Commands.CreateOutcome;

public record CreateOutcomeCommand(AppOutcome NewOutcome) : IRequest<Guid>;
