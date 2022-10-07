using Dapper;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;

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
}
