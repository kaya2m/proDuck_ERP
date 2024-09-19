
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;

namespace proDuck.Domain.Entities.Customer;

public class TBL_Customer : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int PaymentMethod { get; set; }
    public string CountryCode { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
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
    public ICollection<TBL_Offer> Offer { get; set; }
    public ICollection<TBL_Order> Orders { get; set; }
    public virtual ICollection<TBL_ShippingAddress> ShippingAddresses { get; set; }
}
