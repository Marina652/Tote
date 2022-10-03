namespace Tote.Application.SportType.Common.Interfaces;

public interface ISportTypeReader
{
    Task<Models.SportType> ReadByIdAsync(Guid id, CancellationToken token = default);
}
