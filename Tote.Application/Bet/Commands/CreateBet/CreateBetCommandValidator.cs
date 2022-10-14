using FluentValidation;

namespace Tote.Application.Bet.Commands.CreateBet;

internal class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
{
    public CreateBetCommandValidator()
    {
        RuleFor(b => b.NewBet.Coefficient).NotEmpty().GreaterThan(0);
        RuleFor(b => b.NewBet.Cost).NotEmpty().GreaterThanOrEqualTo(0);
    }
}
