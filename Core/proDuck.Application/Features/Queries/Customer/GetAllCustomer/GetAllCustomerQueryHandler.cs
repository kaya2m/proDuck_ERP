using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.CustomerInterface;

namespace proDuck.Application.Features.Queries.Customer.GetAllCustomer;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
{
    private readonly ICustomerReadRepository customerReadRepository;

    public GetAllCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        this.customerReadRepository = customerReadRepository;
    }

    public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        var allCustomer = await customerReadRepository.GetAllAsync(false);
        var totalCount = allCustomer.Count();

        var customers = customerReadRepository.GetWhere(c=>c.Status == true)
            .Skip(request.Page * request.Size)
              .Take(request.Size).ToList();
        if (customers != null)
        {
            return new GetAllCustomerQueryResponse()
            {
                Data = customers,
                TotalCount = totalCount,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
            };
        }
        else
        {
            return new GetAllCustomerQueryResponse()
            {
                Data = null,
                TotalCount = 0,
                IsSuccessful = false,
                Message = "An error occurred while retrieving customers",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
        
    }
}
