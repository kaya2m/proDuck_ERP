using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Order.Order.GetAllOrder;
using proDuck.Application.Repositories.OrderInterface.Order;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Order.OrderDetail.GetAllOrderDetail
{
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, GetAllOrderDetailQueryResponse>
    {
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetAllOrderDetailQueryHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<GetAllOrderDetailQueryResponse> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _orderDetailReadRepository.GetAllAsync(false);

                var totalCount = await query.CountAsync();

                var orderDetails = await query
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllOrderDetailQueryResponse
                {
                    Data = orderDetails,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };

            }
            catch (Exception ex)
            {
                return new GetAllOrderDetailQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
