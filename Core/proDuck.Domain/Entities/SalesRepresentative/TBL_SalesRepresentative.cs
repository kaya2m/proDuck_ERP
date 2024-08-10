using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.SalesRepresentative
{
    public class TBL_SalesRepresentative : User
    {
        public ICollection<TBL_Offer> Offers { get; set; }
        public ICollection<TBL_Order> Orders { get; set; }
    }
}
