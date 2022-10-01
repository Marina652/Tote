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
    internal class OutcomeBlockWriteRepository : IOutcomeBlockWriter
    {
        private readonly IDbConnection _dbConnection;
        public OutcomeBlockWriteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async ValueTask<Guid> WriteAsync(Application.OutcomeBlock.Common.Models.OutcomeBlock newOutcomeBlock, CancellationToken token)
        {
            using (_dbConnection)
            {
                return await _dbConnection.QuerySingleAsync<Guid>(
               "INSERT INTO OutcomeBlock (Description, EventId) " +
               "OUTPUT INSERTED.[Id]" +
               "VALUES (@Description, @EventId)",
               new { newOutcomeBlock.Description, newOutcomeBlock.EventId });
            }
        }

        public async ValueTask UpdateAsync(Application.OutcomeBlock.Common.Models.OutcomeBlock newOutcomeBlock, CancellationToken token)
        {
            using (_dbConnection)
            {
                await _dbConnection.ExecuteAsync("UPDATE OutcomeBlock SET Description = @Description, EventId = @EventId WHERE Id = @Id",
                    new { newOutcomeBlock.Description, newOutcomeBlock.EventId, newOutcomeBlock.Id });
            }
        }

        public async ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
        {
            using (_dbConnection)
            {
                await _dbConnection.ExecuteAsync("DELETE OutcomeBlock WHERE Id = @id", new { id });
            }
        }
    }
}
