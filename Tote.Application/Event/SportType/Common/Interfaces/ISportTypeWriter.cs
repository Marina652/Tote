namespace Tote.Application.SportType.Common.Interfaces;

public interface ISportTypeWriter
{
    Task<Guid> WriteAsync(Models.SportType newSportType, CancellationToken token = default);

    Task UpdateAsync(Models.SportType newSportType, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
