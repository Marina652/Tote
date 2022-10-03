namespace Tote.Contracts.Event.Event.Requests;

public class UpdateEventRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid SportTypeId { get; set; }
}
