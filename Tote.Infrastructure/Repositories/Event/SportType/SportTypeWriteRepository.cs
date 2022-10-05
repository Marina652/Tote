using Dapper;
using Tote.Application.SportType.Common.Interfaces;


namespace Tote.Infrastructure.Repositories.Event.SportType;

internal sealed class SportTypeWriteRepository : ISportTypeWriter
{
    private readonly IConnectionFactory _connectionFactory;
    public SportTypeWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();
        return await dbConnection.QuerySingleAsync<Guid>(
       "INSERT INTO SportType (Name) " +
       "OUTPUT INSERTED.[Id]" +
       "VALUES (@Name)",
       new { newSportType.Name });
    }

    public async Task UpdateAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE SportType SET Name = @Name WHERE Id = @id",
            new { newSportType.Name, newSportType.Id });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
    }
}
