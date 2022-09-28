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
    internal class EventCreateRepository : IEventWriter
    {
        string connectionString = null;
        public EventCreateRepository(string conn)
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
    }
}
