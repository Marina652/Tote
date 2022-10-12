namespace Tote.Contracts.OutcomeBlock.Market.Responses;

public class GetMarketByIdResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid BlockId { get; set; }
}
