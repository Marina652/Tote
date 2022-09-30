using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.OutcomeBlock.Common.Interfaces;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById
{
    internal class GetOutcomeBlockByIdHandler : IRequestHandler<GetOutcomeBlockByIdQuery, Common.Models.OutcomeBlock>
    {
        private readonly IOutcomeBlockReader _outcomeBlockReader;

        public GetOutcomeBlockByIdHandler(IOutcomeBlockReader outcomeBlockReader)
        {
            _outcomeBlockReader = outcomeBlockReader;
        }

        public async Task<Common.Models.OutcomeBlock> Handle(GetOutcomeBlockByIdQuery request, CancellationToken cancellationToken)
        {
            return await _outcomeBlockReader.ReadByIdAsync(request.Id, cancellationToken);
        }
    }
}
