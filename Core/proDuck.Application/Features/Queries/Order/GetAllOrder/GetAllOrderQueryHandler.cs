using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface;

namespace proDuck.Application.Features.Queries.Order.GetAllOrder;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var allCustomer = await _orderReadRepository.GetAllAsync(false);
        var totalCount = allCustomer.Count();

        var Orders = _orderReadRepository.GetWhere(c => c.Status == true)
            .Skip(request.Page * request.Size)
              .Take(request.Size).ToList();
        if (Orders != null)
        {
            return new GetAllOrderQueryResponse()
            {
                Data = Orders,
                TotalCount = totalCount,
                IsSuccessful = true,
                StatusCode =StatusCodes.Status200OK,
            };
        }
        else
        {
            return new GetAllOrderQueryResponse()
            {
                Data = null,
                TotalCount = 0,
                IsSuccessful = false,
                Message = "An error occurred while retrieving Orders",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
    }
}
