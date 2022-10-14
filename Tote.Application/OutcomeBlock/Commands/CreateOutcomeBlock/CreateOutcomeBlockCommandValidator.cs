using FluentValidation;

namespace Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;

internal class CreateOutcomeBlockCommandValidator : AbstractValidator<CreateOutcomeBlockCommand>
{
    public CreateOutcomeBlockCommandValidator()
    {
        RuleFor(x => x.NewOutcomeBlock.EventId).NotEmpty();

    }
}
