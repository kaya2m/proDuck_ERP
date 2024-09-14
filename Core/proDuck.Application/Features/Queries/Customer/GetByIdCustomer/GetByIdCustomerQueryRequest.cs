using MediatR;

namespace proDuck.Application.Features.Queries.Customer.GetByIdCustomer;

public class GetByIdCustomerQueryRequest : IRequest<GetByIdCustomerQueryResponse>
{
    public Guid id { get; set; }
}
