using Dapper;
using System.Data;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock.Market;

internal sealed class MarketReadRepository : IMarketReader
{
    private readonly IDbConnection _dbConnection;
    public MarketReadRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Application.Market.Common.Models.Market> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            return await _dbConnection.QuerySingleAsync<Application.Market.Common.Models.Market>("SELECT * FROM Market WHERE Id = @id", new { id });

        }
    }
}
