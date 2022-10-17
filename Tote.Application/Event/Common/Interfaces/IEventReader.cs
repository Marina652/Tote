using Tote.Application.Event.Common.Models;

namespace Tote.Application.Event.Common.Interfaces;

public interface IEventReader
{
    Task<FoundEvent> ReadByIdAsync(Guid id, CancellationToken token = default);
}
