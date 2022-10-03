using MediatR;

namespace Tote.Application.Market.Commands.CreateMarket;

public record CreateMarketCommand(Common.Models.Market NewMarket) : IRequest<Guid>;
