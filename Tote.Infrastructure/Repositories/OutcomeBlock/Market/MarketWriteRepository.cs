using Dapper;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock.Market;

internal sealed class MarketWriteRepository : IMarketWriter
{
    private readonly IConnectionFactory _connectionFactory;

    public MarketWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(Application.Market.Common.Models.Market newMarket, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleAsync<Guid>(
       "INSERT INTO Market (Name, BlockId) " +
       "OUTPUT INSERTED.[Id]" +
       "VALUES (@Name, @BlockId)",
       new { newMarket.Name, newMarket.BlockId });
    }

    public async Task UpdateAsync(Application.Market.Common.Models.Market newMarket, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE Market SET Name = @Name, BlockId = @BlockId WHERE Id = @id",
            new { newMarket.Name, newMarket.BlockId, newMarket.Id });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE Market WHERE Id = @id", new { id });
    }
}
