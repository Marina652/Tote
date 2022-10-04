using Dapper;
using System.Data;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock;

internal sealed class OutcomeBlockReadRepository : IOutcomeBlockReader
{
    private readonly IDbConnection _dbConnection;
    public OutcomeBlockReadRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Application.OutcomeBlock.Common.Models.OutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<Application.OutcomeBlock.Common.Models.OutcomeBlock>("SELECT * FROM OutcomeBlock WHERE Id = @id", new { id });
        }
    }
}
