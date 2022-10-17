using MediatR;

namespace Tote.Application.SportType.Commands.DeleteSportType;

public record DeleteSportTypeCommand(Guid Id) : IRequest;
