using MediatR;

namespace Tote.Application.Market.Queries.GetMarketById;

public record GetMarketByIdQuery(Guid Id) : IRequest<Common.Models.Market>;
