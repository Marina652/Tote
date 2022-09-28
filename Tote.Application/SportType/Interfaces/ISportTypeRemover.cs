using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Interfaces
{
    public interface ISportTypeRemover
    {
        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
