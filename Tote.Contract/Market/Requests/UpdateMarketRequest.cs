namespace Tote.Contracts.OutcomeBlock.Market.Requests;

public class UpdateMarketRequest
{
    public string Name { get; set; }

    public Guid BlockId { get; set; }
}
