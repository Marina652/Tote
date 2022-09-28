using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Interfaces;

namespace Tote.Application.SportType.Queries.GetSportTypeById
{
    internal class GetSportTypeByIdHandler : IRequestHandler<GetSportTypeByIdQuery, Common.SportType>
    {
        private readonly ISportTypeReader _sportTypeReader;

        public GetSportTypeByIdHandler(ISportTypeReader sportTypeReader)
        {
            _sportTypeReader = sportTypeReader;
        }

        public async Task<Common.SportType> Handle(GetSportTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var foundSportType = await _sportTypeReader.ReadByIdAsync(request.Id, cancellationToken);
            return foundSportType;
        }
    }
}
