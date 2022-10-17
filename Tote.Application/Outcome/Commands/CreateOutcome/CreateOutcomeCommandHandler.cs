using MediatR;
using Tote.Application.Outcome.Common.Interfaces;

namespace Tote.Application.Outcome.Commands.CreateOutcome;

internal class CreateOutcomeCommandHandler : IRequestHandler<CreateOutcomeCommand, Guid>
{
    private readonly IOutcomeWriter _outcomeWriter;

    public CreateOutcomeCommandHandler(IOutcomeWriter outcomeWriter)
    {
        _outcomeWriter = outcomeWriter;
    }

    public async Task<Guid> Handle(CreateOutcomeCommand request, CancellationToken cancellationToken)
    {
        return await _outcomeWriter.WriteAsync(request.NewOutcome, cancellationToken);
    }
}
