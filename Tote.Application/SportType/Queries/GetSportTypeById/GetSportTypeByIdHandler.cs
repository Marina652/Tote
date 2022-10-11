using MediatR;
using Tote.Application.SportType.Common.Interfaces;
using AppSportType = Tote.Application.SportType.Common.Models.SportType;

namespace Tote.Application.SportType.Queries.GetSportTypeById;

internal class GetSportTypeByIdHandler : IRequestHandler<GetSportTypeByIdQuery, AppSportType>
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
