using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Commands.DeleteSportType
{
    public record DeleteSportTypeCommand(Guid Id) : IRequest;
}
