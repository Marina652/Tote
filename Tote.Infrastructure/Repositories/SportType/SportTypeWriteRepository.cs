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

        public async ValueTask<Guid> WriteAsync(Application.SportType.Common.Models.SportType newEvent, CancellationToken token)
        {
            return await _dbConnection.QuerySingleAsync<Guid>(
               "INSERT INTO SportType (Name) " +
               "OUTPUT INSERTED.[Id]" +
               "VALUES (@Name)",
               new { newEvent.Name });
        }

        public async ValueTask UpdateAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("UPDATE SportType SET Name = @Name WHERE Id = @id",
                    new { newSportType.Name,newSportType.Id });
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            await _dbConnection.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
        }
    }
}
