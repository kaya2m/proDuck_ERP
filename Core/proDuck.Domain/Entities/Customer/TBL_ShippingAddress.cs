using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Customer
{
    public class TBL_ShippingAddress : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string AccountName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Guid TownId { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Postcode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string EmailAddress { get; set; }

        // Navigation properties
        public TBL_Customer Customer { get; set; }
        public ICollection<TBL_Offer> Offer { get; set; }
        public ICollection<TBL_Order> Order { get; set; }
    }
}
