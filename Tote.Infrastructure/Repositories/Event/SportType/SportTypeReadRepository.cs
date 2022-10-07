using Dapper;
using Tote.Application.SportType.Common.Interfaces;
using Tote.Infrastructure.DatabaseConnection;
using AppSportType = Tote.Application.SportType.Common.Models.SportType;

namespace Tote.Infrastructure.Repositories.Event.SportType;

internal sealed class SportTypeReadRepository : ISportTypeReader
{
    private readonly IConnectionFactory _connectionFactory;
    public SportTypeReadRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AppSportType> ReadByIdAsync(Guid id, CancellationToken token)
    {
        using var dbConnection = _connectionFactory.CreateConnection();

        return await dbConnection.QuerySingleOrDefaultAsync<Application.SportType.Common.Models.SportType>("SELECT * FROM SportType WHERE Id = @id", new { id });
    }
}
