using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.SalesRepresentative;
using System;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_OfferMeeting : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string CommunicationType { get; set; }
        public Guid CustomerRepresentativeId { get; set; }
        public string CustomerContactPerson { get; set; }
        public string CustomerContactEmail { get; set; }
        public string CustomerContactPhone { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public virtual TBL_Customer Customer { get; set; }
        public virtual TBL_SalesRepresentative CustomerRepresentative { get; set; }
    }
}
