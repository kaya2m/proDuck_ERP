using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.ProductCard
{
    [Table("category")]
    public class TBL_Category:BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 

        // Navigation properties 
        public ICollection<TBL_ProductCard> ProductCards { get; set; }
    }
}
