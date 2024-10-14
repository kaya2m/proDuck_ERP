using proDuck.Domain.Entities.Address;
using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Stock
{
    [Table("warehouse")]
    public class TBL_Warehouse : BaseEntity
    {
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
        public string PostalCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
        public ICollection<TBL_StockMovement> StockMovements { get; set; }
        public virtual TBL_Country Country { get; set; }
        public virtual TBL_City City { get; set; }
        public virtual TBL_District District { get; set; }
        public virtual TBL_Neighborhood Neighborhood { get; set; }
    }
}
