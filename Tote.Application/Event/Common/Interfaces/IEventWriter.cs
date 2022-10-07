namespace Tote.Application.Event.Common.Interfaces;
using AppEvent = Tote.Application.Event.Common.Models.Event;

public interface IEventWriter
{
    Task<Guid> WriteAsync(AppEvent newEvent, CancellationToken token = default);

    Task UpdateAsync(AppEvent newEvent, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
