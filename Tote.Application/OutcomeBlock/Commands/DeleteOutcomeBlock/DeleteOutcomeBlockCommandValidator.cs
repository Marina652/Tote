using FluentValidation;

namespace Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;

internal class DeleteOutcomeBlockCommandValidator : AbstractValidator<DeleteOutcomeBlockCommand>
{
    public DeleteOutcomeBlockCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
