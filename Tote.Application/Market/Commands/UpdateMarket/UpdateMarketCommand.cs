using MediatR;
using AppMarket = Tote.Application.Market.Common.Models.Market;

namespace Tote.Application.Market.Commands.UpdateMarket;

public record UpdateMarketCommand(AppMarket NewMarket) : IRequest;
