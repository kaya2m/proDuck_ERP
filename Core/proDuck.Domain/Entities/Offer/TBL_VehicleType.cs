using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_VehicleType : BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public int M2 { get; set; }
        public int M3 { get; set; }

        // Navigation properties 
        public ICollection<TBL_Offer> Offer { get; set; }
    }
}
