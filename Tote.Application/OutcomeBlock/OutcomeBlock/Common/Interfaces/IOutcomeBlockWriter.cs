namespace Tote.Application.OutcomeBlock.Common.Interfaces;
using AppOutcomeBlock = Models.OutcomeBlock;

public interface IOutcomeBlockWriter
{
    Task<Guid> WriteAsync(AppOutcomeBlock newOutcomeBlock, CancellationToken token = default);

    Task UpdateAsync(AppOutcomeBlock newOutcomeBlock, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
