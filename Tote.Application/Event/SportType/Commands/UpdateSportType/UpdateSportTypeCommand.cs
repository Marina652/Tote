using MediatR;
using AppSportType = Tote.Application.SportType.Common.Models.SportType;

namespace Tote.Application.SportType.Commands.UpdateSportType;

public record UpdateSportTypeCommand(AppSportType NewSportType) : IRequest;
