using AutoMapper;
using Tote.Application.SportType.Common.Models;
using Tote.Contracts.Event.SportType.Requests;
using Tote.Contracts.Event.SportType.Responses;

namespace Tote.Api.MappingProfiles;

public class SportTypeProfiles : Profile
{
    public SportTypeProfiles()
    {
        CreateMap<CreateSportTypeRequest, SportType>();
        CreateMap<UpdateSportTypeRequest, SportType>();

        CreateMap<SportType, GetSportTypeByIdResponse>();
    }
}
