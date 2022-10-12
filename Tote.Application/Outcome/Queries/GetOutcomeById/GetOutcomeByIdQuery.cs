using MediatR;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Queries.GetOutcomeById;

public record GetOutcomeByIdQuery(Guid Id) : IRequest<AppOutcome>;
