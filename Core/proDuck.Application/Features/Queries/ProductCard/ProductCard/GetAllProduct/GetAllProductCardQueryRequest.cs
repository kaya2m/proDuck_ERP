using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductCard.ProductCard.GetAllProduct
{
    public class GetAllProductCardQueryRequest : IRequest<GetAllProductCardQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
