using Dapper;
using System.Collections.Generic;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;
using AppMarket = Tote.Application.Market.Common.Models.Market;


namespace Tote.Infrastructure.Repositories.OutcomeBlock;

internal sealed class OutcomeBlockReadRepository : IOutcomeBlockReader
{
    private readonly IConnectionFactory _connectionFactory;

    public OutcomeBlockReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AppOutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<AppOutcomeBlock>("SELECT * FROM OutcomeBlock WHERE Id = @id", new { id });
    }

    public async Task<IEnumerable<AppMarket>> GetOutcomeBlockMarketsAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QueryAsync<AppMarket>("SELECT * FROM Market WHERE BlockId = @id", new { id });
    }
}
