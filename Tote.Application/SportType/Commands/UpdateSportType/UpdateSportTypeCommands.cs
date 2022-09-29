﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Commands.UpdatesportType
{
    public record UpdateSportTypeCommand(Common.SportType NewSportType) : IRequest;
}
