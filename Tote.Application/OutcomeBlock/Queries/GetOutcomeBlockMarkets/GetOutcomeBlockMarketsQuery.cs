using MediatR;
using System.Collections.Generic;
using AppMarket = Tote.Application.Market.Common.Models.Market;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockMarkets;

public record GetOutcomeBlockMarketsQuery(Guid Id) : IRequest<IEnumerable<AppMarket>>;
