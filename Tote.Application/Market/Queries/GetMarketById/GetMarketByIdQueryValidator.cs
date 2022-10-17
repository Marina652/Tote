using FluentValidation;

namespace Tote.Application.Market.Queries.GetMarketById;

internal class GetMarketByIdQueryValidator : AbstractValidator<GetMarketByIdQuery>
{
    public GetMarketByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
