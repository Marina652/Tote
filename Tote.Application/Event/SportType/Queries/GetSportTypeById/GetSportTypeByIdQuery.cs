using MediatR;

namespace Tote.Application.SportType.Queries.GetSportTypeById;

public record GetSportTypeByIdQuery(Guid Id) : IRequest<Common.Models.SportType>;
