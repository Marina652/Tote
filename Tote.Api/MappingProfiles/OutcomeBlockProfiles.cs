using AutoMapper;
using Tote.Application.OutcomeBlock.Common.Models;
using Tote.Contracts.OutcomeBlock.Requests;
using Tote.Contracts.OutcomeBlock.Responses;

namespace Tote.Api.MappingProfiles;

public class OutcomeBlockProfiles : Profile
{
    public OutcomeBlockProfiles()
    {
        CreateMap<CreateOutcomeBlockRequest, OutcomeBlock>();
        CreateMap<UpdateOutcomeBlockRequest, OutcomeBlock>();

        CreateMap<OutcomeBlock, GetOutcomeBlockByIdResponse>();
    }
}
