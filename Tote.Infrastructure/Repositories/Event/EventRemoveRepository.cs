﻿using Dapper;
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
    internal class EventRemoveRepository : IEventRemover
    {
        string connectionString = null;

        public EventRemoveRepository(string conn)
        {
            connectionString = conn;
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                    await db.ExecuteAsync("DELETE Event WHERE Id = @id", new { id });       
            }
        }
    }
}
