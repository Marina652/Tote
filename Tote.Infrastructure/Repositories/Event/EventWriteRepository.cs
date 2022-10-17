using Dapper;
using Tote.Application.Event.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppEvent = Tote.Application.Event.Common.Models.Event;

namespace Tote.Infrastructure.Repositories.Event;

internal sealed class EventWriteRepository : IEventWriter
{
    private readonly IConnectionFactory _connectionFactory;

    public EventWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(AppEvent newEvent, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleAsync<Guid>(
             "INSERT INTO Event (Name, Description, StartDate, EndDate, SportTypeId) " +
             "OUTPUT INSERTED.[Id]" +
             "VALUES (@Name, @Description, @StartDate, @EndDate, @SportTypeId)",
             new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE Event WHERE Id = @id", new { id });
    }

    public async Task UpdateAsync(AppEvent newEvent, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE Event SET Name = @Name, Description = @Description, " +
        "StartDate = @StartDate, EndDate = @EndDate, SportTypeId = @SportTypeId WHERE Id = @id",
            new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId, newEvent.Id });
    }
}
