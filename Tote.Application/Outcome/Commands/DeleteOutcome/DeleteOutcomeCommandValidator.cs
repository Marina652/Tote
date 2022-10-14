using FluentValidation;

namespace Tote.Application.Outcome.Commands.DeleteOutcome;

internal class DeleteOutcomeCommandValidator : AbstractValidator<DeleteOutcomeCommand>
{
    public DeleteOutcomeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
