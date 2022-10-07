namespace Tote.Application.Market.Common.Interfaces;
using AppMarket = Models.Market;

public interface IMarketWriter
{
    Task<Guid> WriteAsync(AppMarket newMarket, CancellationToken token = default);

    Task UpdateAsync(AppMarket newMarket, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
