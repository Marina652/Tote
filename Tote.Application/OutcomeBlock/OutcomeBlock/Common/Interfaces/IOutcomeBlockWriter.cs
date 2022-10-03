namespace Tote.Application.OutcomeBlock.Common.Interfaces;

public interface IOutcomeBlockWriter
{
    Task<Guid> WriteAsync(Models.OutcomeBlock newOutcomeBlock, CancellationToken token = default);

    Task UpdateAsync(Models.OutcomeBlock newOutcomeBlock, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
