namespace Tote.Application.Event.Common.Interfaces;

public interface IEventWriter
{
    Task<Guid> WriteAsync(Models.Event newEvent, CancellationToken token = default);

    Task UpdateAsync(Models.Event newEvent, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
