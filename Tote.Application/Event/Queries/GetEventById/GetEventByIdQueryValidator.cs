using FluentValidation;

namespace Tote.Application.Event.Queries.GetEventById
{
    public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
    {
        public GetEventByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
