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
    internal class SportTypeReadRepository : ISportTypeReader
    {
        string connectionString = null;
        public SportTypeReadRepository(string conn)
        {
            connectionString = conn;
        }

        public async ValueTask<Application.SportType.Common.SportType> ReadByIdAsync(Guid id, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return (await db.QueryAsync<Application.SportType.Common.SportType>("SELECT * FROM SportType WHERE Id = @id", new { id })).FirstOrDefault();
            }
        }
    }
}
