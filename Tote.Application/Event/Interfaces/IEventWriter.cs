using GifFiles.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Event.Interfaces
{
    public interface IEventWriter
    {
        ValueTask WriteAsync(Common.Event newEvent, CancellationToken token);
    }
}
