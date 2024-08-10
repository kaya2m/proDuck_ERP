using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.ProductCard
{
    public class TBL_Pallet : BaseEntity
    {
        public string WarehouseName { get; set; }
        public string PalletCode { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string StockName { get; set; }
        public decimal StockQuantity
        {
            get; set;
        }
    }
}
