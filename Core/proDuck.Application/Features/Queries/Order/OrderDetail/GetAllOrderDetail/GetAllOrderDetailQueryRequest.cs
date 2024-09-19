using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Order.OrderDetail.GetAllOrderDetail
{
    public class GetAllOrderDetailQueryRequest : IRequest<GetAllOrderDetailQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
