﻿namespace Tote.Contracts.Event.Event.Requests;

public class CreateEventRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid SportTypeId { get; set; }
}
