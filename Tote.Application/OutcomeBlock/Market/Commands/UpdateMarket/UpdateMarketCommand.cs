using MediatR;

namespace Tote.Application.Market.Commands.UpdateMarket;

public record UpdateMarketCommand(Common.Models.Market NewMarket) : IRequest;
