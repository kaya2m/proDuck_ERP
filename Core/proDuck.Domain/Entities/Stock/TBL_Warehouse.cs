using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Stock
{
    public class TBL_Warehouse : BaseEntity
    {
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public string PostalCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
        public ICollection<TBL_StockMovement> StockMovements { get; set; }
    }
}
