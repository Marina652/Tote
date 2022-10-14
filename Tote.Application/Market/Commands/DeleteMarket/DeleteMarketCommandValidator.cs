using FluentValidation;

namespace Tote.Application.Market.Commands.DeleteMarket;

internal class DeleteMarketCommandValidator : AbstractValidator<DeleteMarketCommand>
{
    public DeleteMarketCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
