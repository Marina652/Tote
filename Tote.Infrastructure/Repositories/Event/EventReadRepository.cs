using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Tote.Application.Event.Common.Models;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.Event
{
    internal class EventReadRepository : IEventReader
    {
        private readonly IDbConnection _dbConnection;
        public EventReadRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<FoundEvent> ReadByIdAsync(Guid id, CancellationToken token)
        {
            using (_dbConnection)
            {
                var sql =
                "SELECT Event.Id, Event.Name, Description, StartDate, EndDate, SportType.Name AS SportTypeName " +
                "FROM Event " +
                "JOIN dbo.SportType ON SportType.Id = Event.SportTypeId " +
                "WHERE Event.Id = @id";

                return (await _dbConnection.QueryAsync<FoundEvent>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
