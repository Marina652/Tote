using FluentValidation;

namespace Tote.Application.Market.Queries.GetMarketOutcomes;

internal class GetMarketOutcomesQueryValidator : AbstractValidator<GetMarketOutcomesQuery>
{
    public GetMarketOutcomesQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
