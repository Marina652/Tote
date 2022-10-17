using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Common.Interfaces;

public interface IOutcomeWriter
{
    Task<Guid> WriteAsync(AppOutcome newOutcome, CancellationToken token = default);

    Task UpdateAsync(AppOutcome newOutcome, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
