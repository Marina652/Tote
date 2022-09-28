using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tote.Application.SportType.Interfaces;

namespace Tote.Infrastructure.Repositories.SportType
{
    internal class SportTypeWriteRepository : ISportTypeWriter
    {
        private readonly IDbConnection _dbConnection;
        public SportTypeWriteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
        }

        ValueTask ISportTypeWriter.UpdateAsync(Application.SportType.Common.SportType newSportType, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        ValueTask ISportTypeWriter.WriteAsync(Application.SportType.Common.SportType newSportType, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
