using FluentValidation;

namespace Tote.Application.Bet.Commands.DeleteBet;

internal class DeleteBetCommandValidator : AbstractValidator<DeleteBetCommand>
{
    public DeleteBetCommandValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
    }
}
