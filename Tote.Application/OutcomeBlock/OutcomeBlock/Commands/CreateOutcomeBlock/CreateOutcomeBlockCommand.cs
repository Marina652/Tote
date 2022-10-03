using MediatR;

namespace Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;

public record CreateOutcomeBlockCommand(Common.Models.OutcomeBlock NewOutcomeBlock) : IRequest<Guid>;
