namespace Tote.Contracts.OutcomeBlock.Market.Requests;

public class CreateMarketRequest
{
    public string Name { get; set; }

    public Guid BlockId { get; set; }
}
