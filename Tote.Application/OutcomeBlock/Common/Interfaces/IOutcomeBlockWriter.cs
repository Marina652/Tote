namespace Tote.Application.OutcomeBlock.Common.Interfaces
{
    public interface IOutcomeBlockWriter
    {
        ValueTask<Guid> WriteAsync(Models.OutcomeBlock newOutcomeBlock, CancellationToken token);

        ValueTask UpdateAsync(Models.OutcomeBlock newOutcomeBlock, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
