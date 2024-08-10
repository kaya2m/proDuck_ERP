using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Machine;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;

namespace proDuck.Domain.Entities.ProductCard
{
    public class TBL_ProductCard : BaseEntity
    {
        public string ProductCode { get; set; }
        public string CustomerProductCode { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public Guid MachineId { get; set; }
        public Guid PalletId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public Guid RepresentativeId { get; set; }
        public string ProductName { get; set; }
        public string CustomProductName { get; set; }
        public string InvoiceDescription { get; set; }
        public string Description { get; set; }
        public string CustomerProductName { get; set; }
        public string InnerDimension { get; set; }
        public string OuterDimension { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public string MachineDescription { get; set; }
        public string CompletionDescription { get; set; }
        public string QualityDescription { get; set; }
        public string ShipmentDescription { get; set; }
        public bool LockStatus { get; set; }
        public bool ApprovalStatus { get; set; }
        public string ProcessStatus { get; set; }
        public decimal LoadingAmount { get; set; }

        // Navigation properties
        public TBL_Customer Customer { get; set; }
        public TBL_ModelType Model { get; set; }
        public TBL_Machine Machine { get; set; }
        public TBL_Pallet Pallet { get; set; }
        public TBL_VehicleType VehicleType { get; set; }
        public TBL_SalesRepresentative Representative { get; set; }
        public ICollection<TBL_OfferDetails> OfferDetails { get; set; }
        public ICollection<TBL_OrderDetails> OrderDetails { get; set; }
    }
}
