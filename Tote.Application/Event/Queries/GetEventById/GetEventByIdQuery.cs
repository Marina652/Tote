using MediatR;
using Tote.Application.Event.Common;

namespace Tote.Application.Event.Queries.GetEventById
{
    public record GetEventByIdQuery(Guid Id) : IRequest<FoundEvent>;
}