using AutoMapper;
using Tote.Application.Bet.Common.Models;
using Tote.Contracts.Bet.Requests;
using Tote.Contracts.Bet.Responses;

namespace Tote.Api.MappingProfiles;

public class BetProfiles : Profile
{
    public BetProfiles()
    {
        CreateMap<CreateBetRequest, Bet>();
        CreateMap<UpdateBetRequest, Bet>();

        CreateMap<Bet, GetBetByIdResponce>();
    }
}
