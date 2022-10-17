using FluentValidation;

namespace Tote.Application.Bet.Queries.GetBetById;

internal class GetBetByIdQueryValidator : AbstractValidator<GetBetByIdQuery>
{
    public GetBetByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
