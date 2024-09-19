using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.Order;

namespace proDuck.Application.Features.Queries.Order.Order.GetByIdOrder;

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
        var isSuccessful = order != null;

        return new GetByIdOrderQueryResponse
        {
            Data = order,
            IsSuccessful = isSuccessful,
            StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
        };
    }
}
