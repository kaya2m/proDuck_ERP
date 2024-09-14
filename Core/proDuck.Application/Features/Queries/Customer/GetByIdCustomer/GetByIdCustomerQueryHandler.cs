using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.CustomerInterface;

namespace proDuck.Application.Features.Queries.Customer.GetByIdCustomer;

public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
{
    private readonly ICustomerReadRepository customerReadRepository;

    public GetByIdCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        this.customerReadRepository = customerReadRepository;
    }

    public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerReadRepository.GetByIdAsync(request.id, false);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        else
        {
            return new GetByIdCustomerQueryResponse
            {
                Data = customer,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
            };

        }
    }
}