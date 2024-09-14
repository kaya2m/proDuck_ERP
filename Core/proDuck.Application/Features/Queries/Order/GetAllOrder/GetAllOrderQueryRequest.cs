using MediatR;

namespace proDuck.Application.Features.Queries.Order.GetAllOrder;

public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
