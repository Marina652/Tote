using MediatR;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;

namespace Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;

public record CreateOutcomeBlockCommand(AppOutcomeBlock NewOutcomeBlock) : IRequest<Guid>;
