namespace Tote.Application.SportType.Common.Interfaces;
using AppSportType = Models.SportType;

public interface ISportTypeReader
{
    Task<AppSportType> ReadByIdAsync(Guid id, CancellationToken token = default);
}
