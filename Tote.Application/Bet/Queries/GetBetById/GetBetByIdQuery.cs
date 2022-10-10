using MediatR;
using AppBet = Tote.Application.Bet.Common.Models.Bet;

namespace Tote.Application.Bet.Queries.GetBetById;

public record GetBetByIdQuery(Guid Id) : IRequest<AppBet>;
