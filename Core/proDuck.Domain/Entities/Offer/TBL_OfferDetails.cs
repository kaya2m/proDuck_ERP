using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.ProductCard;
using System;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_OfferDetails : BaseEntity
    {
        public string SpecialCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public Guid OfferId { get; set; }
        public virtual TBL_Offer Offer { get; set; }

        public Guid ProductCardId { get; set; }
        public virtual TBL_ProductCard ProductCard { get; set; }
    }
}
