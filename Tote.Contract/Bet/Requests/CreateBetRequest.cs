using Tote.Application.Bet.Common.Enums;

namespace Tote.Contracts.Bet.Requests;

public class CreateBetRequest
{
    public decimal Cost { get; set; }

    public Status Status { get; set; }

    public Guid UserId { get; set; }

    public double Coefficient { get; set; }

    public Guid OutcomeId { get; set; }
}
