using MediatR;
using Tote.Application.Outcome.Common.Interfaces;

namespace Tote.Application.Outcome.Commands.DeleteOutcome;

internal class DeleteOutcomeCommandHandler : IRequestHandler<DeleteOutcomeCommand>
{
    private readonly IOutcomeWriter _outcomeWriter;
    private readonly IOutcomeReader _outcomeReader;

    public DeleteOutcomeCommandHandler(IOutcomeWriter outcomeWriter, IOutcomeReader outcomeReader)
    {
        _outcomeWriter = outcomeWriter;
        _outcomeReader = outcomeReader;
    }

    public async Task<Unit> Handle(DeleteOutcomeCommand request, CancellationToken cancellationToken)
    {
        var foundOutcome = await _outcomeReader.ReadByIdAsync(request.Id, cancellationToken);

        if (foundOutcome is null)
            throw new ArgumentException("Object doesn't exist");

        await _outcomeWriter.RemoveByIdAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
