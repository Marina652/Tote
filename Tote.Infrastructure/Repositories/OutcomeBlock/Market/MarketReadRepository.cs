using Dapper;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock.Market;

internal sealed class MarketReadRepository : IMarketReader
{
    private readonly IConnectionFactory _connectionFactory;
    public MarketReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Application.Market.Common.Models.Market> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<Application.Market.Common.Models.Market>("SELECT * FROM Market WHERE Id = @id", new { id });
    }
}
