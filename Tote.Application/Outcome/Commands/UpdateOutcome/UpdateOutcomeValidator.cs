using FluentValidation;

namespace Tote.Application.Outcome.Commands.UpdateOutcome;

internal class UpdateOutcomeValidator : AbstractValidator<UpdateOutcomeCommand>
{
    public UpdateOutcomeValidator()
    {
        RuleFor(x => x.NewOutcome.Id).NotEmpty();

        RuleFor(x => x.NewOutcome.Name).NotEmpty();

        RuleFor(x => x.NewOutcome.CurrentCoefficient).NotEmpty();

        RuleFor(x => x.NewOutcome.MarketId).NotEmpty();
    }
}
