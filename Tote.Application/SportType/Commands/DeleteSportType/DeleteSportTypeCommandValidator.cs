using FluentValidation;

namespace Tote.Application.SportType.Commands.DeleteSportType;

internal class DeleteSportTypeCommandValidator : AbstractValidator<DeleteSportTypeCommand>
{
    public DeleteSportTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
