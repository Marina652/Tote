namespace Tote.Application.OutcomeBlock.Common.Interfaces;
using AppOutcomeBlock = Models.OutcomeBlock;
using AppMarket = Tote.Application.Market.Common.Models.Market;

public interface IOutcomeBlockReader
{
    Task<AppOutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<AppMarket>> GetOutcomeBlockMarketsAsync(Guid id, CancellationToken token = default);
}
