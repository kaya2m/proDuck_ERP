
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using proDuck.Domain.Entities.Address;

namespace proDuck.Domain.Entities.Customer;

[Table("customer")]
public class TBL_Customer : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int PaymentMethod { get; set; }
    public string CountryCode { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public int NeighborhoodId { get; set; }
    public string ContactNumber { get; set; }
    public string ContactNumber2{ get; set; }
    public string Email { get; set; }
    public string Email2 { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string PostCode { get; set; }
    public string CompanyName { get; set; } 
    public string TaxNumber { get; set; }
    public string TaxOffice { get; set; }
    public string idNumber { get; set; }
    public string Notes { get; set; } 

    // Navigation properties 
    public ICollection<TBL_Proposal> Proposal { get; set; }
    public ICollection<TBL_Order> Orders { get; set; }
    public virtual ICollection<TBL_ShippingAddress> ShippingAddresses { get; set; }
    public virtual TBL_Country Country { get; set; }
    public virtual TBL_City City { get; set; }
    public virtual TBL_District District { get; set; }
    public virtual TBL_Neighborhood Neighborhood { get; set; }
}
