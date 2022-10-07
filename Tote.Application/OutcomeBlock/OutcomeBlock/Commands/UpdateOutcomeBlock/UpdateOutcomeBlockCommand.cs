using MediatR;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;

public record UpdateOutcomeBlockCommand(AppOutcomeBlock NewOutcomeBlock) : IRequest;
