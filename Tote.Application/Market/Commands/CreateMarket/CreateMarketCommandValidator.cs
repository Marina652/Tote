using FluentValidation;

namespace Tote.Application.Market.Commands.CreateMarket;

internal class CreateMarketCommandValidator : AbstractValidator<CreateMarketCommand>
{
    public CreateMarketCommandValidator()
    {
        RuleFor(x => x.NewMarket.Id).NotEmpty();
    }
}
