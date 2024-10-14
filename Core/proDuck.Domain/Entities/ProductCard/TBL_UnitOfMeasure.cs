using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Domain.Entities.Common;

namespace proDuck.Domain.Entities.ProductCard
{
    [Table("unitofmeasure")]
    public class TBL_UnitOfMeasure : BaseEntity
    {
        public string Type { get; set; }
        public string Icon { get; set; }
    }
}
