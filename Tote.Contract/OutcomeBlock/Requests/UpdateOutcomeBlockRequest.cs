namespace Tote.Contracts.OutcomeBlock.Requests;

public class UpdateOutcomeBlockRequest
{
    public string Description { get; set; }

    public Guid EventId { get; set; }
}
