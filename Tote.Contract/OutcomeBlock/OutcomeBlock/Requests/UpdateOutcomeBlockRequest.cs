namespace Tote.Contracts.OutcomeBlock.OutcomeBlock.Requests;

public class UpdateOutcomeBlockRequest
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public Guid EventId { get; set; }
}
