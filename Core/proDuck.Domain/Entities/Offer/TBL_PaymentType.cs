﻿using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Offer
{
    public class TBL_PaymentType : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
