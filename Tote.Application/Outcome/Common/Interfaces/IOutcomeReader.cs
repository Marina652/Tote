using System.Collections.Generic;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Common.Interfaces;

public interface IOutcomeReader
{
    Task<AppOutcome> ReadByIdAsync(Guid id, CancellationToken token = default);
}
