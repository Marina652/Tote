using MediatR;
using Tote.Application.Bet.Common.Interfaces;

namespace Tote.Application.Bet.Commands.DeleteBet;

internal class DeleteBetCommandHandler : IRequestHandler<DeleteBetCommand>
{
    private readonly IBetWriter _betWriter;
    private readonly IBetReader _betReader;

    public DeleteBetCommandHandler(IBetWriter betWriter, IBetReader betReader)
    {
        _betWriter = betWriter;
        _betReader = betReader;
    }

    public async Task<Unit> Handle(DeleteBetCommand request, CancellationToken cancellationToken)
    {
        var foundBet = await _betReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundBet is null)
            throw new ArgumentException("Object doesn't exist");

        await _betWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
