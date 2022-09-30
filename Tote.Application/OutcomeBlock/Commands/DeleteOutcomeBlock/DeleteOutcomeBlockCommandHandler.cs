using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock
{
    internal class DeleteOutcomeBlockCommandHandler : IRequestHandler<DeleteOutcomeBlockCommand>
    {
        private readonly IOutcomeBlockWriter _outcomeBlockWriter;

        public DeleteOutcomeBlockCommandHandler(IOutcomeBlockWriter outcomeBlockWriter)
        {
            _outcomeBlockWriter = outcomeBlockWriter;
        }

        public async Task<Unit> Handle(DeleteOutcomeBlockCommand request, CancellationToken cancellationToken)
        {
            await _outcomeBlockWriter.RemoveByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
