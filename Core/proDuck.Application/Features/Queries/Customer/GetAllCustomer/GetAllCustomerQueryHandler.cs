using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        var allCustomers = await customerReadRepository.GetAllAsync(false);
        var totalCount = await customerReadRepository.GetWhere(c => c.Status == true).CountAsync();

        var customers = await customerReadRepository.GetWhere(c => c.Status == true)
            .Include(c => c.Country)
            .Include(ci => ci.City)
            .Include(d => d.District)
            .Include(n => n.Neighborhood)
            .Select(s => new
            {
                s.Id,
                s.Address,
                s.Address2,
                s.Code,
                s.CompanyName,
                s.ContactNumber,
                s.ContactNumber2,
                s.CountryCode,
                s.Email,
                s.Email2,
                s.idNumber,
                s.Name,
                s.Notes,
                s.PaymentMethod,
                s.CurrencyTypes,
                s.TaxNumber,
                s.TaxOffice,
                s.Status,
                s.CreateDate,
                CountryName = s.Country.CountryName,
                CityName = s.City.CityName,
                DistrictName = s.District.DistrictName,
                NeighborhoodName = s.Neighborhood.NeighborhoodName
            })
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .OrderBy(x=>x.CreateDate)
            .ToListAsync();

        if (customers.Any())
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
                TotalCount = 0,
                IsSuccessful = false,
                Message = "No customers found",
                StatusCode = StatusCodes.Status404NotFound,
            };
        }

    }
}
