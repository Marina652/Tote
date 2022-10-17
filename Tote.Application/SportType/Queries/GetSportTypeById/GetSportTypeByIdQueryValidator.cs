using FluentValidation;

namespace Tote.Application.SportType.Queries.GetSportTypeById;

internal class GetSportTypeByIdQueryValidator : AbstractValidator<GetSportTypeByIdQuery>
{
    public GetSportTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
