using MediatR;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Market.Queries.GetMarketOutcomes;

public record GetMarketOutcomesQuery(Guid Id) : IRequest<IEnumerable<AppOutcome>>;
