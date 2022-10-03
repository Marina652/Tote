﻿using Dapper;
using System.Data;
using Tote.Application.Event.Common.Interfaces;

namespace Tote.Infrastructure.Repositories.Event;

internal sealed class EventWriteRepository : IEventWriter
{
    private readonly IDbConnection _dbConnection;
    public EventWriteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> WriteAsync(Application.Event.Common.Models.Event newEvent, CancellationToken token)
    {
        using (_dbConnection)
        {
            return await _dbConnection.QuerySingleAsync<Guid>(
               "INSERT INTO Event (Name, Description, StartDate, EndDate, SportTypeId) " +
               "OUTPUT INSERTED.[Id]" +
               "VALUES (@Name, @Description, @StartDate, @EndDate, @SportTypeId)",
               new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId });
        }
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("DELETE Event WHERE Id = @id", new { id });
        }
    }

    public async Task UpdateAsync(Application.Event.Common.Models.Event newEvent, CancellationToken token)
    {
        using (_dbConnection)
        {
            await _dbConnection.ExecuteAsync("UPDATE Event SET Name = @Name, Description = @Description, " +
            "StartDate = @StartDate, EndDate = @EndDate, SportTypeId = @SportTypeId WHERE Id = @id",
                new { newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.SportTypeId, newEvent.Id });
        }
    }
}
