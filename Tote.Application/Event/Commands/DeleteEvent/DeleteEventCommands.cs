﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Event.Commands.DeleteEvent
{
    public record DeleteEventCommand(Guid Id) : IRequest;
}
