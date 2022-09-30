namespace Tote.Application.Event.Common.Interfaces
{
    public interface IEventWriter
    {
        ValueTask<Guid> WriteAsync(Models.Event newEvent, CancellationToken token);

        ValueTask UpdateAsync(Models.Event newEvent, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
