using MediatR;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Commands.DeleteMarket;

internal class DeleteMarketCommandHandler : IRequestHandler<DeleteMarketCommand>
{
    private readonly IMarketWriter _marketWriter;

    public DeleteMarketCommandHandler(IMarketWriter marketWriter)
    {
        _marketWriter = marketWriter;
    }

    public async Task<Unit> Handle(DeleteMarketCommand request, CancellationToken cancellationToken)
    {
        await _marketWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
