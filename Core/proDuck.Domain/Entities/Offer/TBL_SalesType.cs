using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proDuck.Domain.Entities.Proposal
{
    [Table("salestype")]
    public class TBL_SalesType : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string SalesManager { get; set; }

        // Navigation properties
        public virtual ICollection<TBL_Proposal> Proposals { get; set; }
    }
}
