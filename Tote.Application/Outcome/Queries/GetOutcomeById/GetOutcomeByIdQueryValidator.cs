using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Outcome.Queries.GetOutcomeById
{
    internal class GetOutcomeByIdQueryValidator : AbstractValidator<GetOutcomeByIdQuery>
    {
        public GetOutcomeByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
