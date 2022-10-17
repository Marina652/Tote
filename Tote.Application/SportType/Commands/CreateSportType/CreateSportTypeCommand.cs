using MediatR;
using AppSportType = Tote.Application.SportType.Common.Models.SportType;

namespace Tote.Application.SportType.Commands.CreateSportType;

public record CreateSportTypeCommand(AppSportType NewSportType) : IRequest<Guid>;
