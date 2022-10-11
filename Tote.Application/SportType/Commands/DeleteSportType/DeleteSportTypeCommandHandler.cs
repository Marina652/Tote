using MediatR;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Commands.DeleteSportType;

internal class DeleteSportTypeCommandHandler : IRequestHandler<DeleteSportTypeCommand>
{
    private readonly ISportTypeWriter _sportTypeWriter;
    private readonly ISportTypeReader _sportTypeReader;

    public DeleteSportTypeCommandHandler(ISportTypeWriter sportTypeWriter, ISportTypeReader sportTypeReader)
    {
        _sportTypeWriter = sportTypeWriter;
        _sportTypeReader = sportTypeReader;
    }

    public async Task<Unit> Handle(DeleteSportTypeCommand request, CancellationToken cancellationToken)
    {
        var foundSportType = await _sportTypeReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundSportType is null)
            throw new ArgumentException("Object doesn't exist");

        await _sportTypeWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
