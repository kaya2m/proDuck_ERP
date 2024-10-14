using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Domain.Entities.Address;

namespace proDuck.Domain.Entities.Customer
{
    [Table("shippingaddress")]
    public class TBL_ShippingAddress : BaseEntity
    {
        public string AccountName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
        public string Postcode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string EmailAddress { get; set; }

        // Navigation properties
        public Guid CustomerId { get; set; }
        public TBL_Customer Customer { get; set; }
        public ICollection<TBL_Proposal> Proposal { get; set; }
        public ICollection<TBL_Order> Order { get; set; }
        public virtual TBL_Country Country { get; set; }
        public virtual TBL_City City { get; set; }
        public virtual TBL_District District { get; set; }
        public virtual TBL_Neighborhood Neighborhood { get; set; }
    }
}
