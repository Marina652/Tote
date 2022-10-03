namespace Tote.Application.OutcomeBlock.Common.Interfaces;

public interface IOutcomeBlockReader
{
    Task<Models.OutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token = default);
}
