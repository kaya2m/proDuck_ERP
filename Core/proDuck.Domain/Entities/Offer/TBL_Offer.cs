
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Order;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_Offer : BaseEntity
    {
        public string Type { get; set; }
        public string OfferNumber { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public Guid MeetingId { get; set; }
        public string CompanyNumber { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentTerm { get; set; }
        public Guid SalesRepresentativeId { get; set; }
        public string ContactPerson { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedTotalAmount { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public TBL_Customer Customer { get; set; }
        public TBL_Order Order { get; set; }
        public ICollection<TBL_OfferDetails> OfferDetails { get; set; }
    }
}
