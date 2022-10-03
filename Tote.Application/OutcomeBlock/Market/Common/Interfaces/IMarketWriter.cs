namespace Tote.Application.Market.Common.Interfaces;

public interface IMarketWriter
{
    Task<Guid> WriteAsync(Models.Market newMarket, CancellationToken token = default);

    Task UpdateAsync(Models.Market newMarket, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
