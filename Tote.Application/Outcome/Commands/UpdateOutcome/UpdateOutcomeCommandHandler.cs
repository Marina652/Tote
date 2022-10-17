using MediatR;
using Tote.Application.Outcome.Common.Interfaces;

namespace Tote.Application.Outcome.Commands.UpdateOutcome;

internal class UpdateOutcomeCommandHandler : IRequestHandler<UpdateOutcomeCommand>
{
    private readonly IOutcomeWriter _outcomeWriter;
    private readonly IOutcomeReader _outcomeReader;

    public UpdateOutcomeCommandHandler(IOutcomeWriter outcomeWriter, IOutcomeReader outcomeReader)
    {
        _outcomeWriter = outcomeWriter;
        _outcomeReader = outcomeReader;
    }

    public async Task<Unit> Handle(UpdateOutcomeCommand request, CancellationToken cancellationToken)
    {
        var foundOutcomeBlock = await _outcomeReader.ReadByIdAsync(request.NewOutcome.Id, cancellationToken);

        if (foundOutcomeBlock is null)
            throw new ArgumentException("Object doesn't exist");

        await _outcomeWriter.UpdateAsync(request.NewOutcome, cancellationToken);
        return Unit.Value;
    }
}
