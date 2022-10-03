using MediatR;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;

public record UpdateOutcomeBlockCommand(Common.Models.OutcomeBlock NewOutcomeBlock) : IRequest;
