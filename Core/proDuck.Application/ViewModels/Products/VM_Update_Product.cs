﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.ViewModels.Products
{
    public class VM_Update_Product
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

    }
}
