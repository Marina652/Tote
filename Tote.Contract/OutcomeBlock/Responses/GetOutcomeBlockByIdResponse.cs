﻿namespace Tote.Contracts.OutcomeBlock.Responses;

public class GetOutcomeBlockByIdResponse
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public Guid EventId { get; set; }
}
