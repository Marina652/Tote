using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock;

internal class UpdateOutcomeBlockCommandHandler : IRequestHandler<UpdateOutcomeBlockCommand>
{

    private readonly IOutcomeBlockWriter _outcomeBlockWriter;
    private readonly IOutcomeBlockReader _outcomeBlockReader;

    public UpdateOutcomeBlockCommandHandler(IOutcomeBlockWriter outcomeBlockWriter, IOutcomeBlockReader outcomeBlockReader)
    {
        _outcomeBlockWriter = outcomeBlockWriter;
        _outcomeBlockReader = outcomeBlockReader;
    }

    public async Task<Unit> Handle(UpdateOutcomeBlockCommand request, CancellationToken cancellationToken)
    {
        var foundOutcomeBlock = await _outcomeBlockReader.ReadByIdAsync(request.NewOutcomeBlock.Id, cancellationToken);

        if (foundOutcomeBlock is null)
            throw new ArgumentException("Object doesn't exist");

        await _outcomeBlockWriter.UpdateAsync(request.NewOutcomeBlock, cancellationToken);
        return Unit.Value;
    }
}
