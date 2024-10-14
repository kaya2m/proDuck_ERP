using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proDuck.Domain.Entities.Proposal
{
    [Table("paymenttype")]
    public class TBL_PaymentType : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<TBL_Proposal> Proposals { get; set; }
    }
}
