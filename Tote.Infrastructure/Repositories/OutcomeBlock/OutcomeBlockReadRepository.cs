using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.OutcomeBlock
{
    internal class OutcomeBlockReadRepository : IOutcomeBlockReader
    {
        private readonly IDbConnection _dbConnection;
        public OutcomeBlockReadRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Application.OutcomeBlock.Common.Models.OutcomeBlock> ReadByIdAsync(Guid id, CancellationToken token)
        {
            using (_dbConnection)
            {
                return (await _dbConnection.QueryAsync<Application.OutcomeBlock.Common.Models.OutcomeBlock>("SELECT * FROM OutcomeBlock WHERE Id = @id", new { id })).FirstOrDefault();
            }
        }
    }
}
