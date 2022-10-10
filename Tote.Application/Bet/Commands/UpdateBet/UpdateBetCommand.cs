using MediatR;
using Tote.Application.Bet.Common.Enums;

namespace Tote.Application.Bet.Commands.UpdateBet;

public record UpdateBetCommand(Guid Id, Status Status) : IRequest;
