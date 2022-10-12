using MediatR;
using Tote.Application.Outcome.Common.Interfaces;
using AppOutcome = Tote.Application.Outcome.Common.Models.Outcome;

namespace Tote.Application.Outcome.Queries.GetOutcomeById
{
    internal class GetOutcomeByIdHandler : IRequestHandler<GetOutcomeByIdQuery, AppOutcome>
    {
        private readonly IOutcomeReader _outcomeReader;

        public GetOutcomeByIdHandler(IOutcomeReader outcomeReader)
        {
            _outcomeReader = outcomeReader;
        }

        public async Task<AppOutcome> Handle(GetOutcomeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _outcomeReader.ReadByIdAsync(request.Id, cancellationToken);
        }
    }
}
