using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tote.Application.SportType.Common.Interfaces;


namespace Tote.Infrastructure.Repositories.SportType
{
    internal class SportTypeWriteRepository : ISportTypeWriter
    {
        private readonly IDbConnection _dbConnection;
        public SportTypeWriteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Guid> WriteAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
        {
            using (_dbConnection)
            {
                return await _dbConnection.QuerySingleAsync<Guid>(
               "INSERT INTO SportType (Name) " +
               "OUTPUT INSERTED.[Id]" +
               "VALUES (@Name)",
               new { newSportType.Name });
            }
        }

        public async ValueTask UpdateAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
        {
            using (_dbConnection)
            {
                await _dbConnection.ExecuteAsync("UPDATE SportType SET Name = @Name WHERE Id = @id",
                    new { newSportType.Name, newSportType.Id });
            }
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            using (_dbConnection)
            {
                await _dbConnection.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
            }
        }
    }
}
