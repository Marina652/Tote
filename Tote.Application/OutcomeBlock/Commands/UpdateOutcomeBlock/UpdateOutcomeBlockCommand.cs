using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.OutcomeBlock.Commands.UpdateOutcomeBlock
{
    public record UpdateOutcomeBlockCommand(Common.Models.OutcomeBlock NewOutcomeBlock) : IRequest;
}
