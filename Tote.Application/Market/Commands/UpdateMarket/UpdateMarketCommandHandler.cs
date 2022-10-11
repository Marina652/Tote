using MediatR;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Commands.UpdateMarket;

internal class UpdateMarketCommandHandler : IRequestHandler<UpdateMarketCommand>
{
    private readonly IMarketWriter _marketWriter;
    private readonly IMarketReader _marketReader;

    public UpdateMarketCommandHandler(IMarketWriter marketWriter, IMarketReader marketReader)
    {
        _marketWriter = marketWriter;
        _marketReader = marketReader;
    }

    public async Task<Unit> Handle(UpdateMarketCommand request, CancellationToken cancellationToken)
    {
        var foundMarket = await _marketReader.ReadByIdAsync(request.NewMarket.Id, cancellationToken);

        if (foundMarket is null)
            throw new ArgumentException("Object doesn't exist");

        await _marketWriter.UpdateAsync(request.NewMarket, cancellationToken);
        return Unit.Value;
    }
}
