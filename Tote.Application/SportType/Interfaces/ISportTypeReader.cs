using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Interfaces
{
    public interface ISportTypeReader
    {
        ValueTask<Common.SportType> ReadByIdAsync(Guid id, CancellationToken token);
    }
}
