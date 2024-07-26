using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.RequestParameters
{
    public record Pagination
    {
        public int Page{ get; init; } = 0;
        public int Size { get; init; } = 5;
       
    }
}
