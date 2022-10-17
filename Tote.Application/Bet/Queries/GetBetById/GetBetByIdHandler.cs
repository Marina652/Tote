using MediatR;
using Tote.Application.Bet.Common.Interfaces;
using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Application.Bet.Queries.GetBetById;

internal class GetBetByIdHandler : IRequestHandler<GetBetByIdQuery, AppBet>
{
    private readonly IBetReader _betReader;

    public GetBetByIdHandler(IBetReader betReader)
    {
        _betReader = betReader;
    }

    public async Task<AppBet> Handle(GetBetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _betReader.ReadByIdAsync(request.Id, cancellationToken);
    }
}
