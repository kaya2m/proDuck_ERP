using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductCard.ProductCard.GetAllProduct
{
    public class GetAllProductCardQueryResponse : ResponseDto<GetAllProductCardQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
