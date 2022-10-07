namespace Tote.Application.SportType.Common.Interfaces;
using AppSportType = Models.SportType;

public interface ISportTypeWriter
{
    Task<Guid> WriteAsync(AppSportType newSportType, CancellationToken token = default);

    Task UpdateAsync(AppSportType newSportType, CancellationToken token = default);

    Task RemoveByIdAsync(Guid id, CancellationToken token = default);
}
