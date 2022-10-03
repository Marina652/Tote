﻿namespace Tote.Contracts.Event.Event.Responses;

public class GetEventByIdResponse
{

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string SportTypeName { get; set; }
};
