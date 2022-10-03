using MediatR;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Queries.GetMarketById;

internal class GetMarketByIdHandler : IRequestHandler<GetMarketByIdQuery, Common.Models.Market>
{
    private readonly IMarketReader _marketReader;

    public GetMarketByIdHandler(IMarketReader marketReader)
    {
        _marketReader = marketReader;
    }

    public async Task<Common.Models.Market> Handle(GetMarketByIdQuery request, CancellationToken cancellationToken)
    {
        return await _marketReader.ReadByIdAsync(request.Id, cancellationToken);
    }
}
