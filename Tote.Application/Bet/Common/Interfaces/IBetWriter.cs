using Tote.Application.Bet.Common.Enums;
using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Application.Bet.Common.Interfaces;

public interface IBetWriter
{
    Task<Guid> WriteAsync(AppBet newBet, CancellationToken token = default);

    Task UpdateStatusAsync(Guid Id, Status newStatus, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
