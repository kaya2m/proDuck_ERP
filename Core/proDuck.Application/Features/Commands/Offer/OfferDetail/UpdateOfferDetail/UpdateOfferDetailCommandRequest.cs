﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.UpdateOfferDetail
{
    public class UpdateOfferDetailCommandRequest : IRequest<UpdateOfferDetailCommandResponse>
    {
        public Guid id { get; set; }
        public string StockNumber { get; set; }
        public int SerialNumber { get; set; }
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

        public Guid ProductCardId { get; set; }
        public Guid OfferId { get; set; }
    }
}
