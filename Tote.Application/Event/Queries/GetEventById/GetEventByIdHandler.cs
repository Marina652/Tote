using MediatR;
using Tote.Application.Event.Interfaces;

namespace Tote.Application.Event.Queries.GetEventById
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery, Common.Event>
    {
        private readonly IEventReader _eventReader;

        public GetEventByIdHandler(IEventReader eventReader)
        {
            _eventReader = eventReader;
        }

        public async Task<Common.Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var foundEvent = await _eventReader.ReadByIdAsync(request.Id, cancellationToken);
            return foundEvent;
        }
    }
}
