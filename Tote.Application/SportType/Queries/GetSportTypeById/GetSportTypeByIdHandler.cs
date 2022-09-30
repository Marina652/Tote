using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.SportType.Common.Interfaces;

namespace Tote.Application.SportType.Queries.GetSportTypeById
{
    internal class GetSportTypeByIdHandler : IRequestHandler<GetSportTypeByIdQuery, Common.Models.SportType>
    {
        private readonly ISportTypeReader _sportTypeReader;

        public GetSportTypeByIdHandler(ISportTypeReader sportTypeReader)
        {
            _sportTypeReader = sportTypeReader;
        }

        public async Task<Common.Models.SportType> Handle(GetSportTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sportTypeReader.ReadByIdAsync(request.Id, cancellationToken);
        }
    }
}
