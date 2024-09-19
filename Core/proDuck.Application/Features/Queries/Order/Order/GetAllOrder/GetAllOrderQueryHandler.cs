using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Repositories.OrderInterface.Order;

namespace proDuck.Application.Features.Queries.Order.Order.GetAllOrder;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _orderReadRepository.GetAll(false);

            var totalCount = await query.CountAsync();

            var orders = await query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            return new GetAllOrderQueryResponse
            {
                Data = orders,
                TotalCount = totalCount,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };

        }
        catch (Exception ex)
        {
            return new GetAllOrderQueryResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }
    }
}
