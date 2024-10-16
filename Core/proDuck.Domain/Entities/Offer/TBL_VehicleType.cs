﻿using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proDuck.Domain.Entities.Proposal
{
    [Table("vehicletype")]
    public class TBL_VehicleType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int M2 { get; set; }
        public int M3 { get; set; }

        // Navigation properties
        public virtual ICollection<TBL_Proposal> Proposals { get; set; }
    }
}
