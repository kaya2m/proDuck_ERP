﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Order.OrderDetail.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandRequest : IRequest<DeleteOrderDetailCommandResponse>
    {
        public  Guid id { get; set; }
    }
}
