using FluentValidation;

namespace Tote.Application.Event.Commands.DeleteEvent;

internal class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
{
    public DeleteEventCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
