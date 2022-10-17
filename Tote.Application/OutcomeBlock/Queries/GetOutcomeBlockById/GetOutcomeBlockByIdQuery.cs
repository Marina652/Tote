using MediatR;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;

public record GetOutcomeBlockByIdQuery(Guid Id) : IRequest<AppOutcomeBlock>;
