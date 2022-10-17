using MediatR;
using Tote.Application.Bet.Common.Interfaces;

namespace Tote.Application.Bet.Commands.CreateBet;

internal class CreateBetCommandHandler : IRequestHandler<CreateBetCommand, Guid>
{
    private readonly IBetWriter _betWriter;

    public CreateBetCommandHandler(IBetWriter betWriter)
    {
        _betWriter = betWriter;
    }

    public async Task<Guid> Handle(CreateBetCommand request, CancellationToken cancellationToken)
    {
        return await _betWriter.WriteAsync(request.NewBet, cancellationToken);
    }
}
