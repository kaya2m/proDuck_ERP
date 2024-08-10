using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.ProductCard
{
    public class TBL_Category:BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 

        // Navigation properties 
        public ICollection<TBL_ProductCard> ProductCards { get; set; }
    }
}
