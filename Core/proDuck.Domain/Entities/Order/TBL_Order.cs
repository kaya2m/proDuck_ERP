using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Identity;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Order
{
    public class TBL_Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public Guid OfferId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string PaymentMethod { get; set; }
        public string SubPaymentMethod { get; set; }
        public Guid TermId { get; set; }
        public string SalesRepresentative { get; set; }
        public string ContactPerson { get; set; }
        public string SalesType { get; set; }
        public string SubSalesType { get; set; }
        public Guid CustomerRepresentativeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CustomerOrderNumber { get; set; }
        public Guid RepresentativeId { get; set; }

        // Navigation properties
        public TBL_Offer Offer { get; set; }
        public TBL_Customer Customer { get; set; }
        public TBL_SalesRepresentative Representative { get; set; }
    }
}
