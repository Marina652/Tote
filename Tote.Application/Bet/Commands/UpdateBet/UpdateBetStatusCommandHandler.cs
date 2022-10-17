using MediatR;
using Tote.Application.Bet.Common.Interfaces;

namespace Tote.Application.Bet.Commands.UpdateBet;

internal class UpdateBetStatusCommandHandler : IRequestHandler<UpdateBetStatusCommand>
{
    private readonly IBetWriter _betWriter;
    private readonly IBetReader _betReader;

    public UpdateBetStatusCommandHandler(IBetWriter betWriter, IBetReader betReader)
    {
        _betWriter = betWriter;
        _betReader = betReader;
    }

    public async Task<Unit> Handle(UpdateBetStatusCommand request, CancellationToken cancellationToken)
    {
        var foundBet = await _betReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundBet is null)
            throw new ArgumentException("Object doesn't exist");

        await _betWriter.UpdateStatusAsync(request.Id, request.Status, cancellationToken);
        return Unit.Value;
    }
}
