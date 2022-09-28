using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Interfaces;

namespace Tote.Application.SportType.Commands.DeleteSportType
{
    internal class DeleteSportTypeCommandHandler : IRequestHandler<DeleteSportTypeCommand>
    {
        private readonly ISportTypeRemover _sportTypeRemover;

        public DeleteSportTypeCommandHandler(ISportTypeRemover sportTypeRemover)
        {
            _sportTypeRemover = sportTypeRemover;
        }

        public async Task<Unit> Handle(DeleteSportTypeCommand request, CancellationToken cancellationToken)
        {
            await _sportTypeRemover.RemoveByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
