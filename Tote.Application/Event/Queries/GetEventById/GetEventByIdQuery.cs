using MediatR;

namespace Tote.Application.Event.Queries.GetEventById
{
    public record GetEventByIdQuery(int Id) : IRequest<Common.Event>;
}