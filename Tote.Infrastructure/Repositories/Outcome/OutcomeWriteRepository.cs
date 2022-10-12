using Dapper;
using Tote.Application.Outcome.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Infrastructure.Repositories.Outcome;

internal sealed class OutcomeWriteRepository : IOutcomeWriter
{
    private readonly IConnectionFactory _connectionFactory;

    public OutcomeWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(AppOutcome newOutcome, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleAsync<Guid>(
       "INSERT INTO Outcome (Name, CurrentCoefficient, MarketId) " +
       "OUTPUT INSERTED.[Id]" +
       "VALUES (@Name, @CurrentCoefficient, @MarketId)",
       new { newOutcome.Name, newOutcome.CurrentCoefficient, newOutcome.MarketId });
    }

    public async Task UpdateAsync(AppOutcome newOutcome, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE Outcome SET Name = @Name, " +
            "CurrentCoefficient = @CurrentCoefficient, MarketId = @MarketId WHERE Id = @Id",
            new { newOutcome.Name, newOutcome.CurrentCoefficient, 
                newOutcome.MarketId, newOutcome.Id });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE Outcome WHERE Id = @id", new { id });
    }
}
