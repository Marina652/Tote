namespace Tote.Contracts.Outcome.Responses;

public class GetOutcomeByIdResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double CurrentCoefficient { get; set; }

    public Guid MarketId { get; set; }
}
