using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Identity;
using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Order
{
    [Table("order")]
    public class TBL_Order : BaseEntity
    {
        public string OrderName { get; set; }
        public string OrderNumber { get; set; }
        public Guid ProposalId { get; set; }
        public Guid CustomerId { get; set; }
        public string StockNumber { get; set; }
        public string SerialNumber { get; set; }
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
        public TBL_Proposal Proposal { get; set; }
        public TBL_Customer Customer { get; set; }
        public TBL_SalesRepresentative Representative { get; set; }
    }
}
