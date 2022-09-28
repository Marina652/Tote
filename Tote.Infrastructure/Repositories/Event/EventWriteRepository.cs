using Dapper;
using GifFiles.Application.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;

namespace Tote.Infrastructure.Repositories.Event
{
    internal class EventWriteRepository : IEventWriter
    {
        string connectionString = null;
        public EventWriteRepository(string conn)
        {
            connectionString = conn;
        }

        public async ValueTask WriteAsync(Application.Event.Common.Event newEvent, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                await db.ExecuteAsync("INSERT INTO Event (Name, Description, StartDate, EndDate, SportTypeId) " +
                    "VALUES (@Name, @Description, @StartDate, @EndDate, @SportTypeId)", 
                    new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId });
            }
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                await db.ExecuteAsync("DELETE Event WHERE Id = @id", new { id });
            }
        }

        public async ValueTask UpdateAsync(Application.Event.Common.Event newEvent, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                await db.ExecuteAsync("UPDATE Event SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate, SportTypeId = @SportTypeId WHERE Id = @id",
                    new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId, newEvent.Id });
            }
        }
    }
}
