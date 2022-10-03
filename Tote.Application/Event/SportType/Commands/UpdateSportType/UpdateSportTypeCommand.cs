using MediatR;

namespace Tote.Application.SportType.Commands.UpdateSportType;

public record UpdateSportTypeCommand(Common.Models.SportType NewSportType) : IRequest;
