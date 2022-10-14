using FluentValidation;

namespace Tote.Application.Event.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.NewEvent.Name).NotEmpty();

        RuleFor(e => e)
            .Must(e => e.NewEvent.StartDate >= DateTime.Now 
            && e.NewEvent.StartDate <= e.NewEvent.EndDate)
            .WithMessage("Invalid start or(and) end date provided!");
    }
}
