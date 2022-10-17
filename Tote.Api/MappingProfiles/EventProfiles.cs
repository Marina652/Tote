using AutoMapper;
using Tote.Application.Event.Common.Models;
using Tote.Contracts.Event.Requests;
using Tote.Contracts.Event.Responses;

namespace Tote.Api.MappingProfiles;

public class EventProfiles : Profile
{
    public EventProfiles()
    {
        CreateMap<CreateEventRequest, Event>();
        CreateMap<UpdateEventRequest, Event>();

        CreateMap<FoundEvent, GetEventByIdResponse>();
    }
}
