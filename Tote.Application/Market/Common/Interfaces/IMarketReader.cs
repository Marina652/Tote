using AppMarket = Tote.Application.Market.Common.Models.Market;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Market.Common.Interfaces;

public interface IMarketReader
{
    Task<AppMarket> ReadByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<AppOutcome>> GetMarketOutcomesAsync(Guid id, CancellationToken token = default);
}
