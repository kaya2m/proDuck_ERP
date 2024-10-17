using MediatR;
using proDuck.Application.Repositories.CustomerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Google.Apis.Requests.BatchRequest;
using proDuck.Application.Features.Commands.AppUser.CreateUser;
using Microsoft.AspNetCore.Http;

namespace proDuck.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                CountryId = request.CountryId,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                NeighborhoodId = request.NeighborhoodId,
                CountryCode = request.CountryCode,
                Code = await GenerateCustomerCodeAsync(),
                CompanyName = request.CompanyName,
                ContactNumber2 = request.ContactNumber2,
                Email2 = request.Email2,
                Address2 = request.Address2,
                PostCode = request.PostCode,
                PaymentMethod = request.PaymentMethod,
                CurrencyTypes = request.CurrencyTypes,
                TaxNumber = request.TaxNumber,
                TaxOffice = request.TaxOffice,
                Notes = request.Notes,
                idNumber =request.idNumber,

            });
            if(customer == true)
            {
                await _customerWriteRepository.SaveChangesAsync();

                return new CreateCustomerCommandResponse
                {
                    Message = "Customer created successfully",
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status201Created,
                };
            }
            else
            {
                return new CreateCustomerCommandResponse
                {
                    Message = "Customer creation failed",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
      
        }
        private async Task<string> GenerateCustomerCodeAsync()
        {
            var lastCustomer = await _customerReadRepository.GetAll().ToListAsync();

            int newCodeNumber = 1;

            if (lastCustomer != null)
            {
                var numericPart = lastCustomer.Count();
                if (numericPart>0)
                {
                    newCodeNumber = numericPart+1;
                }
            }
            return $"CUS-{newCodeNumber:D5}";
        }
    }
}
