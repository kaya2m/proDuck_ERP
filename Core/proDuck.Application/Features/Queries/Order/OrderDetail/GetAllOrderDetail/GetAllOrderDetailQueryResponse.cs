using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Order.OrderDetail.GetAllOrderDetail
{
    public class GetAllOrderDetailQueryResponse : ResponseDto<GetAllOrderDetailQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
