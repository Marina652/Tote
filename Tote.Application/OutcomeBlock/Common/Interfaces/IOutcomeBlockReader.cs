﻿namespace Tote.Application.OutcomeBlock.Common.Interfaces
{
    public interface IOutcomeBlockReader
    {
        ValueTask<Models.OutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token);
    }
}
