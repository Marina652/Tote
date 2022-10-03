﻿using MediatR;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Commands.DeleteSportType;

internal class DeleteSportTypeCommandHandler : IRequestHandler<DeleteSportTypeCommand>
{
    private readonly ISportTypeWriter _sportTypeWriter;

    public DeleteSportTypeCommandHandler(ISportTypeWriter sportTypeWriter)
    {
        _sportTypeWriter = sportTypeWriter;
    }

    public async Task<Unit> Handle(DeleteSportTypeCommand request, CancellationToken cancellationToken)
    {
        await _sportTypeWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
