using Tote.Application.Bet.Common.Enums;

namespace Tote.Application.Bet.Common.Models;

public class Bet
{
    public Guid Id { get; set; }

    public decimal Cost { get; set; }

    public Status Status { get; set; }

    public Guid UserId { get; set; }

    public double Coefficient { get; set; }

    public Guid OutcomeId { get; set; }
}
