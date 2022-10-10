using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Application.Bet.Common.Interfaces;

public interface IBetReader
{
    Task<AppBet> ReadByIdAsync(Guid id, CancellationToken token = default);
}
