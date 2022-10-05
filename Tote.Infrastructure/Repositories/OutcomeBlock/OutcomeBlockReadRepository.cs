using Dapper;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock;

internal sealed class OutcomeBlockReadRepository : IOutcomeBlockReader
{
    private readonly IConnectionFactory _connectionFactory;

    public OutcomeBlockReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Application.OutcomeBlock.Common.Models.OutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<Application.OutcomeBlock.Common.Models.OutcomeBlock>("SELECT * FROM OutcomeBlock WHERE Id = @id", new { id });
    }
}
