using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.SportType
{
    internal class SportTypeReadRepository : ISportTypeReader
    {
        private readonly IDbConnection _dbConnection;
        public SportTypeReadRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Application.SportType.Common.Models.SportType> ReadByIdAsync(Guid id, CancellationToken token)
        {
            return (await _dbConnection.QueryAsync<Application.SportType.Common.Models.SportType>("SELECT * FROM SportType WHERE Id = @id", new { id })).FirstOrDefault();
        }
    }
}
