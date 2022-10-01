using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Commands.DeleteMarket
{
    public record DeleteMarketCommand(Guid Id) : IRequest;
}
