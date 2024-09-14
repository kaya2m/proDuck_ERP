using proDuck.Application.DTOs;

namespace proDuck.Application.Features.Queries.Customer.GetAllCustomer;

public class GetAllCustomerQueryResponse : ResponseDto<GetAllCustomerQueryResponse>
{
    public int TotalCount { get; set; }
}
