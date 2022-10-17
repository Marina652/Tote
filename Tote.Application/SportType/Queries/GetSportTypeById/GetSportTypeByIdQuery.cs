using MediatR;
using AppSportType = Tote.Application.SportType.Common.Models.SportType;

namespace Tote.Application.SportType.Queries.GetSportTypeById;

public record GetSportTypeByIdQuery(Guid Id) : IRequest<AppSportType>;
