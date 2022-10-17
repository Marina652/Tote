using Dapper;
using Tote.Application.Market.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppMarket = Tote.Application.Market.Common.Models.Market;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Infrastructure.Repositories.OutcomeBlock.Market;

internal sealed class MarketReadRepository : IMarketReader
{
    private readonly IConnectionFactory _connectionFactory;
    public MarketReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AppMarket> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<AppMarket>("SELECT * FROM Market WHERE Id = @id", new { id });
    }

    public async Task<IEnumerable<AppOutcome>> GetMarketOutcomesAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QueryAsync<AppOutcome>("SELECT * FROM Outcome WHERE MarketId = @id", new { id });
    }
}
