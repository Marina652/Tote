using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.OutcomeBlock.Commands.DeleteOutcomeBlock
{
    public record DeleteOutcomeBlockCommand(Guid Id) : IRequest;
}
