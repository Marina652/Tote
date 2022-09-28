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
        private readonly IDbConnection _dbConnection;
        public EventReadRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Application.Event.Common.Event> ReadByIdAsync(Guid id, CancellationToken token)
        {
            return (await _dbConnection.QueryAsync<Application.Event.Common.Event>("SELECT * FROM Event WHERE Id = @id", new { id })).FirstOrDefault();
        }
    }
}
