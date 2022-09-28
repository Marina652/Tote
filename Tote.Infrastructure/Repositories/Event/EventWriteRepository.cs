using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tote.Application.Event.Interfaces;

namespace Tote.Infrastructure.Repositories.Event
{
    internal class EventWriteRepository : IEventWriter
    {
        private readonly IDbConnection _dbConnection;
        public EventWriteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask WriteAsync(Application.Event.Common.Event newEvent, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("INSERT INTO Event (Name, Description, StartDate, EndDate, SportTypeId) " +
                   "VALUES (@Name, @Description, @StartDate, @EndDate, @SportTypeId)",
                   new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId });
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("DELETE Event WHERE Id = @id", new { id });
        }

        public async ValueTask UpdateAsync(Application.Event.Common.Event newEvent, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("UPDATE Event SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate, SportTypeId = @SportTypeId WHERE Id = @id",
                    new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId, newEvent.Id });
        }
    }
}
