using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tote.Application.Market.Common.Models
{
    public class Market
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public Guid BlockId { get; set; }
    }
}
