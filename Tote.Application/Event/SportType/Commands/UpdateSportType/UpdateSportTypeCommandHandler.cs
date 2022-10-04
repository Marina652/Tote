using MediatR;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Commands.UpdateSportType;

internal class UpdateSportTypeCommandHandler : IRequestHandler<UpdateSportTypeCommand>
{

    private readonly ISportTypeWriter _sportTypeWriter;
    private readonly ISportTypeReader _sportTypeReader;

    public UpdateSportTypeCommandHandler(ISportTypeWriter sportTypeWriter, ISportTypeReader sportTypeReader)
    {
        _sportTypeWriter = sportTypeWriter;
        _sportTypeReader = sportTypeReader;
    }

    public async Task<Unit> Handle(UpdateSportTypeCommand request, CancellationToken cancellationToken)
    {
        var foundSportType = await _sportTypeReader.ReadByIdAsync(request.NewSportType.Id, cancellationToken);

        if (foundSportType is null)
            throw new ArgumentException("Object doesn't exist");

        await _sportTypeWriter.UpdateAsync(request.NewSportType, cancellationToken);
        return Unit.Value;
    }
}
