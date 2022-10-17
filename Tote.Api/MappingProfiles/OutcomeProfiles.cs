using AutoMapper;
using Tote.Application.Outcome.Common.Models;
using Tote.Contracts.Outcome.Requests;
using Tote.Contracts.Outcome.Responses;

namespace Tote.Api.MappingProfiles;

public class OutcomeProfiles : Profile
{
    public OutcomeProfiles()
    {
        CreateMap<CreateOutcomeRequest, Outcome>();
        CreateMap<UpdateOutcomeRequest, Outcome>();

        CreateMap<Outcome, GetOutcomeByIdResponse>();
    }
}
