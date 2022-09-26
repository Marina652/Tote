using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Interfaces;

namespace Tote.Infrastructure.Repositories.Event
{
    internal class EventReadRepository : IEventReader
    {
        public ValueTask<Application.Event.Common.Event> ReadByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
