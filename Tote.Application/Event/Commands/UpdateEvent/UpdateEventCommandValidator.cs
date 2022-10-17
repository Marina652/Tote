using FluentValidation;

namespace Tote.Application.Event.Commands.UpdateEvent;

internal class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.NewEvent.Id).NotEmpty();

        RuleFor(e => e)
          .Must(e => e.NewEvent.StartDate >= DateTime.Now
          && e.NewEvent.StartDate <= e.NewEvent.EndDate)
          .WithMessage("Invalid start or(and) end date provided!");
    }
}
