using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Interfaces
{
    public interface ISportTypeWriter
    {
        ValueTask WriteAsync(Common.SportType newSportType, CancellationToken token);

        ValueTask UpdateAsync(Common.SportType newSportType, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
