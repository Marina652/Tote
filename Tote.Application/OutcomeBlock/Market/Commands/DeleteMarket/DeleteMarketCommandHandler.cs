using MediatR;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Commands.DeleteMarket;

internal class DeleteMarketCommandHandler : IRequestHandler<DeleteMarketCommand>
{
    private readonly IMarketWriter _marketWriter;
    private readonly IMarketReader _marketReader;

    public DeleteMarketCommandHandler(IMarketWriter marketWriter, IMarketReader marketReader)
    {
        _marketWriter = marketWriter;
        _marketReader = marketReader;
    }

    public async Task<Unit> Handle(DeleteMarketCommand request, CancellationToken cancellationToken)
    {
        var foundMarket = await _marketReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundMarket is null)
            throw new ArgumentException("Object doesn't exist");

        await _marketWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
