using FluentValidation;

namespace Tote.Application.SportType.Commands.CreateSportType;

internal class CreateSportTypeCommandValidator : AbstractValidator<CreateSportTypeCommand>
{
    public CreateSportTypeCommandValidator()
    {
        RuleFor(x => x.NewSportType.Name).NotEmpty();
    }
}
