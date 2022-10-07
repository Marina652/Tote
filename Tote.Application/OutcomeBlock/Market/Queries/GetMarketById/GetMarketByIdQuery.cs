using MediatR;
using AppMarket = Tote.Application.Market.Common.Models.Market;

namespace Tote.Application.Market.Queries.GetMarketById;

public record GetMarketByIdQuery(Guid Id) : IRequest<AppMarket>;
