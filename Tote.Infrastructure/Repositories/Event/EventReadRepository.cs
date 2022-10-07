using Dapper;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;

namespace Tote.Infrastructure.Repositories.Event;

internal sealed class EventReadRepository : IEventReader
{
    private readonly IConnectionFactory _connectionFactory;
    public EventReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<FoundEvent> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        var sql =
        "SELECT Event.Id, Event.Name, Description, StartDate, EndDate, SportType.Name AS SportTypeName " +
        "FROM Event " +
        "JOIN dbo.SportType ON SportType.Id = Event.SportTypeId " +
        "WHERE Event.Id = @id";

        return await dbConnection.QuerySingleOrDefaultAsync<FoundEvent>(sql, new { id });
    }
}
