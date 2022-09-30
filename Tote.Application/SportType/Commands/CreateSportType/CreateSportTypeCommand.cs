using MediatR;

namespace Tote.Application.SportType.Commands.CreateSportType
{
    public record CreateSportTypeCommand(Common.Models.SportType NewSportType) : IRequest<Guid>;
}
