namespace Tote.Application.Event.Interfaces
{
    public interface IEventWriter
    {
        ValueTask WriteAsync(Common.Event newEvent, CancellationToken token);

        ValueTask UpdateAsync(Common.Event newEvent, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
