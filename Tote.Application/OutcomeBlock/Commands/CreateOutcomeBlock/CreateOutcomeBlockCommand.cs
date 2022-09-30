using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.OutcomeBlock.Commands.CreateOutcomeBlock
{
    public record CreateOutcomeBlockCommand(Common.Models.OutcomeBlock NewOutcomeBlock) : IRequest<Guid>;
}
