﻿using MediatR;
using Tote.Application.Event.Common.Interfaces;
using Tote.Application.Event.Common.Models;

namespace Tote.Application.Event.Queries.GetEventById;

public class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery, FoundEvent>
{
    private readonly IEventReader _eventReader;

    public GetEventByIdHandler(IEventReader eventReader)
    {
        _eventReader = eventReader;
    }

    public async Task<FoundEvent> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var foundEvent = await _eventReader.ReadByIdAsync(request.Id, cancellationToken);
        return foundEvent;
    }
}
