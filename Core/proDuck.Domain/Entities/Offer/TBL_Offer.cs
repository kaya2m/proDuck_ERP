using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Order;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_Offer : BaseEntity
    {
        public string Type { get; set; }
        public string OfferNumber { get; set; }
        public string CompanyNumber { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentTerm { get; set; }
        public string ContactPerson { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedTotalAmount { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public Guid CustomerId { get; set; }
        public virtual TBL_Customer Customer { get; set; }
        public Guid OrderId { get; set; }
        public virtual TBL_Order Order { get; set; }
        public Guid ShippingAddressId { get; set; }
        public virtual TBL_ShippingAddress ShippingAddress { get; set; }
        public Guid MeetingId { get; set; }
        public virtual TBL_OfferMeeting Meeting { get; set; }
        public Guid SalesRepresentativeId { get; set; }
        public virtual TBL_SalesRepresentative SalesRepresentative { get; set; }
        public Guid VehicleTypeId { get; set; }
        public virtual TBL_VehicleType VehicleType { get; set; }
        public Guid PaymentTypeId { get; set; }
        public virtual TBL_PaymentType PaymentType { get; set; }
        public Guid SalesTypeId { get; set; }
        public virtual TBL_SalesType SalesType { get; set; }
        public virtual ICollection<TBL_OfferDetails> OfferDetails { get; set; }
    }
}
