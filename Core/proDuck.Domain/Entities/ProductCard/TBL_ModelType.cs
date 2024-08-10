using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.ProductCard
{
    public class TBL_ModelType :BaseEntity 
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Formula { get; set; }
    }
}
