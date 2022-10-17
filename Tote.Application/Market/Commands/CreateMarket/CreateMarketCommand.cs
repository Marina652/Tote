using MediatR;
using AppMarket = Tote.Application.Market.Common.Models.Market;

namespace Tote.Application.Market.Commands.CreateMarket;

public record CreateMarketCommand(AppMarket NewMarket) : IRequest<Guid>;
