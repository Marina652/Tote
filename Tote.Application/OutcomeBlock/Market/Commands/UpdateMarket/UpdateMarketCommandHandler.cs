using MediatR;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Commands.UpdateMarket;

internal class UpdateMarketCommandHandler : IRequestHandler<UpdateMarketCommand>
{
    private readonly IMarketWriter _marketWriter;

    public UpdateMarketCommandHandler(IMarketWriter marketWriter)
    {
        _marketWriter = marketWriter;
    }

    public async Task<Unit> Handle(UpdateMarketCommand request, CancellationToken cancellationToken)
    {
        await _marketWriter.UpdateAsync(request.NewMarket, cancellationToken);
        return Unit.Value;
    }
}
