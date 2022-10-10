using Tote.Application.Bet.Common.Enums;

namespace Tote.Contracts.Bet.Responses;

public class GetBetByIdResponce
{
    public Guid Id { get; set; }

    public decimal Cost { get; set; }

    public string Status { get; set; }

    public Guid UserId { get; set; }

    public double Coefficient { get; set; }

    public Guid OutcomeId { get; set; }
}
