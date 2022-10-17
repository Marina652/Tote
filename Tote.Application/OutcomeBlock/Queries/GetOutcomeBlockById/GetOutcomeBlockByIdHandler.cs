using MediatR;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using AppOutcomeBlock = Tote.Application.OutcomeBlock.Common.Models.OutcomeBlock;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById;

internal class GetOutcomeBlockByIdHandler : IRequestHandler<GetOutcomeBlockByIdQuery, AppOutcomeBlock>
{
    private readonly IOutcomeBlockReader _outcomeBlockReader;

    public GetOutcomeBlockByIdHandler(IOutcomeBlockReader outcomeBlockReader)
    {
        _outcomeBlockReader = outcomeBlockReader;
    }

    public async Task<AppOutcomeBlock> Handle(GetOutcomeBlockByIdQuery request, CancellationToken cancellationToken)
    {
        return await _outcomeBlockReader.ReadByIdAsync(request.Id, cancellationToken);
    }
}
