using MediatR;

namespace Tote.Application.Market.Commands.DeleteMarket;

public record DeleteMarketCommand(Guid Id) : IRequest;
