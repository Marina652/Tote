using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Queries.GetMarketById
{
    public record GetMarketByIdQuery(Guid Id) : IRequest<Common.Models.Market>;
}
