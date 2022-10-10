using Dapper;
using Tote.Infrastructure.DatabaseConnection;
using Tote.Application.Bet.Common.Interfaces;
using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Infrastructure.Repositories.Event;

internal sealed class BetReadRepository : IBetReader
{
    private readonly IConnectionFactory _connectionFactory;
    public BetReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AppBet> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<AppBet>("SELECT * FROM Bet WHERE Id = @id", new { id });
    }
}
