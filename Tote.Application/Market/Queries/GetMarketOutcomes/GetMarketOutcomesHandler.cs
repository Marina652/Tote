using MediatR;
using Tote.Application.Market.Common.Interfaces;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Market.Queries.GetMarketOutcomes;

internal class GetMarketOutcomesHandler : IRequestHandler<GetMarketOutcomesQuery, IEnumerable<AppOutcome>>
{
    private readonly IMarketReader _marketReader;

    public GetMarketOutcomesHandler(IMarketReader marketReader)
    {
        _marketReader = marketReader;
    }

    public async Task<IEnumerable<AppOutcome>> Handle(GetMarketOutcomesQuery request, CancellationToken cancellationToken)
    {
        return await _marketReader.GetMarketOutcomesAsync(request.Id, cancellationToken);
    }
}
