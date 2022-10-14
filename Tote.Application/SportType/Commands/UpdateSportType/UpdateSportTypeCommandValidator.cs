using FluentValidation;

namespace Tote.Application.SportType.Commands.UpdateSportType;

internal class UpdateSportTypeCommandValidator : AbstractValidator<UpdateSportTypeCommand>
{
    public UpdateSportTypeCommandValidator()
    {
        RuleFor(x => x.NewSportType.Id).NotEmpty();

        RuleFor(x => x.NewSportType.Name).NotEmpty();
    }
}
