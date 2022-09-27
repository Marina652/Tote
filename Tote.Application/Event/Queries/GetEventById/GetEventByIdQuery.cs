using MediatR;

namespace Tote.Application.Event.Queries.GetEventById
{
    public record GetEventByIdQuery(Guid Id) : IRequest<Common.Event>;
}