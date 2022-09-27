using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Tote.Infrastructure.Repositories.Event
{
    internal class EventReadRepository : IEventReader
    {
        string connectionString = null;
        public EventReadRepository(string conn)
        {
            connectionString = conn;
        }

        public async ValueTask<Application.Event.Common.Event> ReadByIdAsync(Guid id, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return (await db.QueryAsync<Application.Event.Common.Event>("SELECT * FROM Event WHERE Id = @id", new { id })).FirstOrDefault();
            }
        }
    }
}
