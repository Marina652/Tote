using MediatR;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Commands.CreateSportType;

internal class CreateSportTypeCommandHandler : IRequestHandler<CreateSportTypeCommand, Guid>
{
    private readonly ISportTypeWriter _sportTypeWriter;

    public CreateSportTypeCommandHandler(ISportTypeWriter sportTypeWriter)
    {
        _sportTypeWriter = sportTypeWriter;
    }

    public async Task<Guid> Handle(CreateSportTypeCommand request, CancellationToken cancellationToken)
    {
        return await _sportTypeWriter.WriteAsync(request.NewSportType, cancellationToken);
    }
}
