namespace Tote.Application.Event.Common.Models;

public class FoundEvent
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string SportTypeName { get; set; }
}
