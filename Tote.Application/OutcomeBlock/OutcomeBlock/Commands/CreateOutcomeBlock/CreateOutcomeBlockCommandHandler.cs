using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock;

internal class CreateOutcomeBlockCommandHandler : IRequestHandler<CreateOutcomeBlockCommand, Guid>
{
    private readonly IOutcomeBlockWriter _outcomeBlockWriter;

    public CreateOutcomeBlockCommandHandler(IOutcomeBlockWriter soutcomeBlockWriter)
    {
        _outcomeBlockWriter = soutcomeBlockWriter;
    }

    public async Task<Guid> Handle(CreateOutcomeBlockCommand request, CancellationToken cancellationToken)
    {
        return await _outcomeBlockWriter.WriteAsync(request.NewOutcomeBlock, cancellationToken);
    }
}
