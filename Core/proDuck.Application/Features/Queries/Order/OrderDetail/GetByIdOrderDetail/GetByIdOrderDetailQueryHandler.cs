using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Order.Order.GetByIdOrder;
using proDuck.Application.Repositories.OrderInterface.Order;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Order.OrderDetail.GetByIdOrderDetail
{
    public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQueryRequest, GetByIdOrderDetailQueryResponse>
    {
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetByIdOrderDetailQueryHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<GetByIdOrderDetailQueryResponse> Handle(GetByIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = orderDetail != null;

            return new GetByIdOrderDetailQueryResponse
            {
                Data = orderDetail,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
