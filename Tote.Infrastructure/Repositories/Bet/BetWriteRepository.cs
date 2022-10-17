using Dapper;
using Tote.Application.Bet.Common.Enums;
using Tote.Application.Bet.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Infrastructure.Repositories.Bet;

internal sealed class BetWriteRepository : IBetWriter
{
    private readonly IConnectionFactory _connectionFactory;

    public BetWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(AppBet newBet, CancellationToken token = default)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleAsync<Guid>(
       "INSERT INTO Bet (Cost, Status, UserId, Coefficient, OutcomeId) " +
       "OUTPUT INSERTED.[Id]" +
       "VALUES (@Cost, @Status, @UserId, @Coefficient, @OutcomeId)",
       new { newBet.Cost, Status = newBet.Status.ToString(), newBet.UserId, newBet.Coefficient, newBet.OutcomeId });
    }

    public async Task UpdateStatusAsync(Guid Id, Status newStatus, CancellationToken token = default)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE Bet SET Status = @Status WHERE Id = @Id",
        new { Status = newStatus.ToString(), Id });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token = default)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE Bet WHERE Id = @id", new { id });
    }
}
