namespace Tote.Contracts.Event.Requests;

public class UpdateEventRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid SportTypeId { get; set; }
}
