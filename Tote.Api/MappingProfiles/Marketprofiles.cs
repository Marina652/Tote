using AutoMapper;
using Tote.Application.Market.Common.Models;
using Tote.Contracts.OutcomeBlock.Market.Requests;
using Tote.Contracts.OutcomeBlock.Market.Responses;

namespace Tote.Api.MappingProfiles;

public class Marketprofiles : Profile
{
    public Marketprofiles()
    {
        CreateMap<CreateMarketRequest, Market>();
        CreateMap<UpdateMarketRequest, Market>();

        CreateMap<Market, GetMarketByIdResponse>();
    }
}
