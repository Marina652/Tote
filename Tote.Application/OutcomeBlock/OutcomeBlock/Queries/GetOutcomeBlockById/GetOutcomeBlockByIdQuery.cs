using MediatR;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;

public record GetOutcomeBlockByIdQuery(Guid Id) : IRequest<Common.Models.OutcomeBlock>;
