using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Commands.CreateSportType
{
    public record CreateSportTypeCommand(Common.SportType NewSportType) : IRequest<Guid>;
}
