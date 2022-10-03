using System.Data;
using Dapper;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.Event;

internal sealed class EventReadRepository : IEventReader
{
    private readonly IDbConnection _dbConnection;
    public EventReadRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<FoundEvent> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            var sql =
            "SELECT Event.Id, Event.Name, Description, StartDate, EndDate, SportType.Name AS SportTypeName " +
            "FROM Event " +
            "JOIN dbo.SportType ON SportType.Id = Event.SportTypeId " +
            "WHERE Event.Id = @id";

            return await _dbConnection.QuerySingleAsync<FoundEvent>(sql, new { id });
        }
    }
}
