using FluentValidation;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;

internal class UpdateOutcomeBlockCommandValidator : AbstractValidator<UpdateOutcomeBlockCommand>
{
    public UpdateOutcomeBlockCommandValidator()
    {
        RuleFor(x => x.NewOutcomeBlock.Id).NotEmpty();

        RuleFor(x => x.NewOutcomeBlock.EventId).NotEmpty();
    }
}
