namespace Tote.Application.SportType.Common.Interfaces
{
    public interface ISportTypeReader
    {
        ValueTask<Models.SportType> ReadByIdAsync(Guid id, CancellationToken token);
    }
}
