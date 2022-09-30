using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Commands.UpdatesportType
{
    internal class UpdateSportTypeCommandHandler : IRequestHandler<UpdateSportTypeCommand>
    {

        private readonly ISportTypeWriter _sportTypeWriter;

        public UpdateSportTypeCommandHandler(ISportTypeWriter sportTypeWriter)
        {
            _sportTypeWriter = sportTypeWriter;
        }

        public async Task<Unit> Handle(UpdateSportTypeCommand request, CancellationToken cancellationToken)
        {
            await _sportTypeWriter.UpdateAsync(request.NewSportType, cancellationToken);
            return Unit.Value;
        }
    }
}
