using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock
{
    internal class UpdateOutcomeBlockCommandHandler : IRequestHandler<UpdateOutcomeBlockCommand>
    {

        private readonly IOutcomeBlockWriter _outcomeBlockWriter;

        public UpdateOutcomeBlockCommandHandler(IOutcomeBlockWriter outcomeBlockWriter)
        {
            _outcomeBlockWriter = outcomeBlockWriter;
        }

        public async Task<Unit> Handle(UpdateOutcomeBlockCommand request, CancellationToken cancellationToken)
        {
            await _outcomeBlockWriter.UpdateAsync(request.NewOutcomeBlock, cancellationToken);
            return Unit.Value;
        }
    }
}
