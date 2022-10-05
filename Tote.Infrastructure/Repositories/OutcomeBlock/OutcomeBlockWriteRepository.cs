using Dapper;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock;

internal sealed class OutcomeBlockWriteRepository : IOutcomeBlockWriter
{
    private readonly IConnectionFactory _connectionFactory;

    public OutcomeBlockWriteRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> WriteAsync(Application.OutcomeBlock.Common.Models.OutcomeBlock newOutcomeBlock, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleAsync<Guid>(
       "INSERT INTO OutcomeBlock (Description, EventId) " +
       "OUTPUT INSERTED.[Id]" +
       "VALUES (@Description, @EventId)",
       new { newOutcomeBlock.Description, newOutcomeBlock.EventId });
    }

    public async Task UpdateAsync(Application.OutcomeBlock.Common.Models.OutcomeBlock newOutcomeBlock, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("UPDATE OutcomeBlock SET Description = @Description, EventId = @EventId WHERE Id = @Id",
            new { newOutcomeBlock.Description, newOutcomeBlock.EventId, newOutcomeBlock.Id });
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        await dbConnection.ExecuteAsync("DELETE OutcomeBlock WHERE Id = @id", new { id });
    }
}
