using MediatR;
using AppBet = Tote.Application.Bet.Common.Models.Bet;


namespace Tote.Application.Bet.Commands.CreateBet;

public record CreateBetCommand(AppBet NewBet) : IRequest<Guid>;
