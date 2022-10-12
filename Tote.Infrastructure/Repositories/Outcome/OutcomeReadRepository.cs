using Dapper;
using Tote.Application.Outcome.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Infrastructure.Repositories.Outcome;

internal sealed class OutcomeReadRepository : IOutcomeReader
{
    private readonly IConnectionFactory _connectionFactory;

    public OutcomeReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AppOutcome> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<AppOutcome>("SELECT * FROM Outcome WHERE Id = @id", new { id });
    }
}
