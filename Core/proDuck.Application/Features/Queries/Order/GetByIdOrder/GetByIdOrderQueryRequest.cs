using MediatR;
namespace proDuck.Application.Features.Queries.Order.GetByIdOrder;

public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
{
    public Guid id { get; set; }
}
