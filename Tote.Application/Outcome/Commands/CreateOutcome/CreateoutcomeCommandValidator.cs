using FluentValidation;

namespace Tote.Application.Outcome.Commands.CreateOutcome;

internal class CreateoutcomeCommandValidator : AbstractValidator<CreateOutcomeCommand>
{
    public CreateoutcomeCommandValidator()
    {
        RuleFor(x => x.NewOutcome.Name).NotEmpty();

        RuleFor(x => x.NewOutcome.CurrentCoefficient).NotEmpty();

        RuleFor(x => x.NewOutcome.MarketId).NotEmpty();
    }
}
