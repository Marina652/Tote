using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock;

internal class DeleteOutcomeBlockCommandHandler : IRequestHandler<DeleteOutcomeBlockCommand>
{
    private readonly IOutcomeBlockWriter _outcomeBlockWriter;
    private readonly IOutcomeBlockReader _outcomeBlockReader;

    public DeleteOutcomeBlockCommandHandler(IOutcomeBlockWriter outcomeBlockWriter, IOutcomeBlockReader outcomeBlockReader)
    {
        _outcomeBlockWriter = outcomeBlockWriter;
        _outcomeBlockReader = outcomeBlockReader;
    }

    public async Task<Unit> Handle(DeleteOutcomeBlockCommand request, CancellationToken cancellationToken)
    {
        var foundOutcomeBlock = await _outcomeBlockReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundOutcomeBlock is null)
            throw new ArgumentException("Object doesn't exist");

        await _outcomeBlockWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
