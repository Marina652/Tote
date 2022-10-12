namespace Tote.Contracts.Outcome.Requests;

public class UpdateOutcomeRequest
{
    public string Name { get; set; }

    public double CurrentCoefficient { get; set; }

    public Guid MarketId { get; set; }
}
