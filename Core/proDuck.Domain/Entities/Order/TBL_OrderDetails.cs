﻿using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.ProductCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Order
{
    public class TBL_OrderDetails : BaseEntity
    {
        public int OrderSequence { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderId { get; set; }
        public int OfferId { get; set; }
        public int OfferDetailId { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string SpecialCode { get; set; }
        public int ProductCardId { get; set; }
        public decimal Price { get; set; }
        public decimal CurrencyPrice { get; set; }
        public string CurrencyType { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal FreightUnitPrice { get; set; }
        public decimal FreightIncludedPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductionQuantity { get; set; }
        public int LoadingQuantity { get; set; }
        public int PalletCount { get; set; }
        public decimal Amount { get; set; }
        public int UnitOfMeasureId { get; set; }
        public DateTime ProductionDeadline { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public string VehicleType { get; set; }
        public Guid ShippingAddressId { get; set; }
        public decimal FreightUnitCost { get; set; }
        public bool ApprovalStatus { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal ProductSalesUnitPrice { get; set; }
        public decimal Rate { get; set; }

        // Navigation properties
        public TBL_Customer Customer { get; set; }
        public TBL_Order Order { get; set; }
        public TBL_Offer Offer { get; set; }
        public TBL_ProductCard ProductCard { get; set; }
        public TBL_ShippingAddress ShippingAddress { get; set; }
    }
}