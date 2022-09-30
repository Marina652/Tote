﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.SportType.Queries.GetSportTypeById
{
    public record GetSportTypeByIdQuery(Guid Id) : IRequest<Common.Models.SportType>;
}
