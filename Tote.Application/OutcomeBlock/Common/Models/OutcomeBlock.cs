using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.OutcomeBlock.Common.Models
{
    public class OutcomeBlock
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid EventId { get; set; }
    }
}
