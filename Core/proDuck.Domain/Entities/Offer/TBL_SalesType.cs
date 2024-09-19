using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_SalesType : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string SalesManager { get; set; }

        // Navigation properties
        public virtual ICollection<TBL_Offer> Offers { get; set; }
    }
}
