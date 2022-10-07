namespace Tote.Application.Market.Common.Interfaces;
using AppMarket = Models.Market;

public interface IMarketReader
{
    Task<AppMarket> ReadByIdAsync(Guid id, CancellationToken token = default);
}
