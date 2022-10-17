namespace Tote.Application.Outcome.Common.Models;

public class Outcome
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double CurrentCoefficient { get; set; }

    public Guid MarketId { get; set; }
}
