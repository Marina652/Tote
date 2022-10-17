using FluentValidation;

namespace Tote.Application.Market.Commands.UpdateMarket;

internal class UpdateMarketCommandValidator : AbstractValidator<UpdateMarketCommand>
{
    public UpdateMarketCommandValidator()
    {
        RuleFor(x => x.NewMarket.Id).NotEmpty();
    }
}
