using MediatR;
namespace proDuck.Application.Features.Queries.Customer.GetAllCustomer;

public class GetAllCustomerQueryRequest : IRequest<GetAllCustomerQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
