using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Event.Common;

namespace Tote.Application.Event.Interfaces
{
    public interface IEventReader
    {
        ValueTask<FoundEvent> ReadByIdAsync(Guid id, CancellationToken token);
    }
}
