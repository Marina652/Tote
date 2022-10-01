using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Commands.UpdateMarket
{
    public record UpdateMarketCommand(Common.Models.Market NewMarket) : IRequest;
}
