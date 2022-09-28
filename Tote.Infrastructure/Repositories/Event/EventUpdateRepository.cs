using Dapper;
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
    internal class EventUpdateRepository : IEventUpdater
    {
        string connectionString = null;

        public EventUpdateRepository(string conn)
        {
            connectionString = conn;
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
