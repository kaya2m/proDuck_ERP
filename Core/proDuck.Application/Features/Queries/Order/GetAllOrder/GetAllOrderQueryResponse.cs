using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.DTOs;

namespace proDuck.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryResponse : ResponseDto<GetAllOrderQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
