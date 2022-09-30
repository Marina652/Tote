using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.OutcomeBlock.Queries.GetOutcomeBlockById
{
    public record GetOutcomeBlockByIdQuery(Guid Id) : IRequest<Common.Models.OutcomeBlock>;
}
