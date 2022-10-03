using Dapper;
using System.Data;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock.Market;

internal sealed class MarketWriteRepository : IMarketWriter
{
    private readonly IDbConnection _dbConnection;
    public MarketWriteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> WriteAsync(Application.Market.Common.Models.Market newMarket, CancellationToken token)
    {
        using (_dbConnection)
        {
            return await _dbConnection.QuerySingleAsync<Guid>(
           "INSERT INTO Market (Name, BlockId) " +
           "OUTPUT INSERTED.[Id]" +
           "VALUES (@Name, @BlockId)",
           new { newMarket.Name, newMarket.BlockId });
        }
    }

    public async Task UpdateAsync(Application.Market.Common.Models.Market newMarket, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("UPDATE Market SET Name = @Name, BlockId = @BlockId WHERE Id = @id",
                new { newMarket.Name, newMarket.BlockId, newMarket.Id });
        }
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("DELETE Market WHERE Id = @id", new { id });
        }
    }
}
