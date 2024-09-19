using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.Offer.UpdateOffer
{
    public class UpdateOfferCommandRequest : IRequest<UpdateOfferCommandResponse>
    {
        public Guid id { get; set; }
        public string   Type { get; set; }
        public string   OfferNumber { get; set; }
        public string   CompanyNumber { get; set; }
        public string   PaymentMethod { get; set; }
        public int      PaymentTerm { get; set; }
        public string   ContactPerson { get; set; }
        public string   Description { get; set; }
        public string   Unit { get; set; }
        public decimal  TotalAmount { get; set; }
        public decimal  DiscountedTotalAmount { get; set; }
        public DateTime Date { get; set; }

        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public Guid MeetingId { get; set; }
        public Guid SalesRepresentativeId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid SalesTypeId { get; set; }
    }
}
