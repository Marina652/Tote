namespace Tote.Application.Market.Common.Interfaces;

public interface IMarketReader
{
    Task<Models.Market> ReadByIdAsync(Guid id, CancellationToken token = default);
}
