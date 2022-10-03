using Dapper;
using System.Data;
using Tote.Application.SportType.Common.Interfaces;


namespace Tote.Infrastructure.Repositories.Event.SportType;

internal sealed class SportTypeWriteRepository : ISportTypeWriter
{
    private readonly IDbConnection _dbConnection;
    public SportTypeWriteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> WriteAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
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

    public async Task UpdateAsync(Application.SportType.Common.Models.SportType newSportType, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("UPDATE SportType SET Name = @Name WHERE Id = @id",
                new { newSportType.Name, newSportType.Id });
        }
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("DELETE SportType WHERE Id = @id", new { id });
        }
    }
}
