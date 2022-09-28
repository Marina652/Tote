using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Interfaces;

namespace Tote.Infrastructure.Repositories.SportType
{
    internal class SportTypeRemoveRepository : ISportTypeRemover
    {
        string connectionString = null;

        public SportTypeRemoveRepository(string conn)
        {
            connectionString = conn;
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                await db.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
            }
        }
    }
}
