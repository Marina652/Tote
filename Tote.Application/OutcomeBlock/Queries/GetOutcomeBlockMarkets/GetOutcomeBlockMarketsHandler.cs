using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using AppMarket = Tote.Application.Market.Common.Models.Market;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockMarkets;

internal class GetOutcomeBlockMarketsHandler : IRequestHandler<GetOutcomeBlockMarketsQuery, IEnumerable<AppMarket>>
{
    private readonly IOutcomeBlockReader _outcomeBlockReader;

    public GetOutcomeBlockMarketsHandler(IOutcomeBlockReader outcomeBlockReader)
    {
        _outcomeBlockReader = outcomeBlockReader;
    }

    public async Task<IEnumerable<AppMarket>> Handle(GetOutcomeBlockMarketsQuery request, CancellationToken cancellationToken)
    {
        return await _outcomeBlockReader.GetOutcomeBlockMarketsAsync(request.Id, cancellationToken);
    }
}
