using FluentValidation;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockMarkets;

internal class GetOutcomeBlockMarketsQueryValidator : AbstractValidator<GetOutcomeBlockMarketsQuery>
{
    public GetOutcomeBlockMarketsQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
