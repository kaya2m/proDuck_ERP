using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Order.OrderDetail.GetByIdOrderDetail
{
    public class GetByIdOrderDetailQueryRequest : IRequest<GetByIdOrderDetailQueryResponse>
    {
        public Guid id { get; set; }
    }
}
