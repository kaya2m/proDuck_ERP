using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Customer.GetByIdCustomer;
using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Repositories.OrderInterface;

namespace proDuck.Application.Features.Queries.Order.GetByIdOrder;

public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.GetByIdAsync(request.id, false);
        if (order == null)
        {
            return new GetByIdOrderQueryResponse
            {
                Data = null,
                IsSuccessful = false,
                StatusCode = StatusCodes.Status404NotFound,
            };
        }
        else
        {
            return new GetByIdOrderQueryResponse
            {
                Data = order,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
            };

        }
    }
}
