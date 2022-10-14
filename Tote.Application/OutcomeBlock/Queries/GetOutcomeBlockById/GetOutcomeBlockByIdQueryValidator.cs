using FluentValidation;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;

internal class GetOutcomeBlockByIdQueryValidator : AbstractValidator<GetOutcomeBlockByIdQuery>
{
    public GetOutcomeBlockByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
