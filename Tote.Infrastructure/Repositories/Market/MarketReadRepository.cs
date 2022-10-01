using Dapper;
using System.Data;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.Market
{
    internal class MarketReadRepository : IMarketReader
    {
        private readonly IDbConnection _dbConnection;
        public MarketReadRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Application.Market.Common.Models.Market> ReadByIdAsync(Guid id, CancellationToken token)
        {
            using (_dbConnection)
            {
                return (await _dbConnection.QueryAsync<Application.Market.Common.Models.Market>("SELECT * FROM Market WHERE Id = @id", new { id })).FirstOrDefault();

            }
        }
    }
}
