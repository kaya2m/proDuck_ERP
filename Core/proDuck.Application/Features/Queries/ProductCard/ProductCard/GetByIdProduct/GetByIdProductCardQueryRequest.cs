using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductCard.ProductCard.GetByIdProduct
{
    public class GetByIdProductCardQueryRequest : IRequest<GetByIdProductCardQueryResponse>
    {
        public Guid id { get; set; }
    }
}
