using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Event.Interfaces
{
    public interface IEventUpdater
    {
        ValueTask UpdateAsync(Common.Event newEvent, CancellationToken token);
    }
}
