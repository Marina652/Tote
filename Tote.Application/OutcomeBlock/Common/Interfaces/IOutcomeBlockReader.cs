namespace Tote.Application.OutcomeBlock.Common.Interfaces;
using AppOutcomeBlock = Models.OutcomeBlock;

public interface IOutcomeBlockReader
{
    Task<AppOutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token = default);
}
