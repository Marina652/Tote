namespace Tote.Application.SportType.Common.Interfaces
{
    public interface ISportTypeWriter
    {
        ValueTask<Guid> WriteAsync(Models.SportType newSportType, CancellationToken token);

        ValueTask UpdateAsync(Models.SportType newSportType, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
