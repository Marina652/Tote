using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Common.Interfaces
{
    public interface IMarketWriter
    {
        ValueTask<Guid> WriteAsync(Models.Market newMarket, CancellationToken token);

        ValueTask UpdateAsync(Models.Market newMarket, CancellationToken token);

        ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
    }
}
