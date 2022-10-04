namespace Tote.Contracts.OutcomeBlock.OutcomeBlock.Requests;

public class CreateOutcomeBlockRequest
{
    public string Description { get; set; }

    public Guid EventId { get; set; }
}
