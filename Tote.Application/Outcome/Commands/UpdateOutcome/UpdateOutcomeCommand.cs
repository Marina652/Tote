using MediatR;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Commands.UpdateOutcome;

public record UpdateOutcomeCommand(AppOutcome NewOutcome) : IRequest;
