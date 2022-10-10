using MediatR;

namespace Tote.Application.Bet.Commands.DeleteBet;

public record DeleteBetCommand(Guid Id) : IRequest;
