using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities
{
    public class InvoiceFiles : Files
    {
        public decimal Price { get; set; }
    }
}
