using Dapper;
using System.Data;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.Event.SportType;

internal sealed class SportTypeReadRepository : ISportTypeReader
{
    private readonly IDbConnection _dbConnection;
    public SportTypeReadRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Application.SportType.Common.Models.SportType> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<Application.SportType.Common.Models.SportType>("SELECT * FROM SportType WHERE Id = @id", new { id });
        }
    }
}
