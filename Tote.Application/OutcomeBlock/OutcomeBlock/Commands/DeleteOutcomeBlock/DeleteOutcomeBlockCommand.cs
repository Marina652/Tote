using MediatR;

namespace Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;

public record DeleteOutcomeBlockCommand(Guid Id) : IRequest;
