using FluentValidation;

namespace Tote.Application.Bet.Commands.UpdateBet;

internal class UpdateBetStatusCommandValidator : AbstractValidator<UpdateBetStatusCommand>
{
    public UpdateBetStatusCommandValidator()
    {
        RuleFor(b => b.Id).NotEmpty();

        RuleFor(b => b.Status).NotEmpty();
    }
}
