using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Common.Interfaces
{
    public interface IMarketReader
    {
        ValueTask<Models.Market> ReadByIdAsync(Guid id, CancellationToken token);
    }
}
