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
           var customerCode = await GenerateCustomerCodeAsync(request.CompanyName);

            var customer = await _customerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                CountryId = request.CountryId,
                CityId = request.CityId,
                TownId = request.TownId,
                CountryCode = request.CountryCode,
                Code = await GenerateCustomerCodeAsync(request.CompanyName),
                CompanyName = request.CompanyName,
                ContactNumber2 = request.ContactNumber2,
                Email2 = request.Email2,
                Address2 = request.Address2,
                PostCode = request.PostCode,
                PaymentMethod = request.PaymentMethod,
                TaxNumber = request.TaxNumber,
                TaxOffice = request.TaxOffice,
                Notes = request.Notes,

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
        private async Task<string> GenerateCustomerCodeAsync(string customerName)
        {
            var prefix = new string(customerName
                                    .Where(char.IsLetter)
                                    .Take(3)
                                    .ToArray())
                         .ToUpper();

            var lastCustomer = await _customerReadRepository
                .GetWhere(c => c.Code.StartsWith(prefix))
                .OrderByDescending(c => c.Code)
                .FirstOrDefaultAsync();

            int newCodeNumber = 1;

            if (lastCustomer != null)
            {
                var numericPart = lastCustomer.Code.Substring(prefix.Length);
                if (int.TryParse(numericPart, out int lastNumber))
                {
                    newCodeNumber = lastNumber + 1;
                }
            }
            return $"CUS-{newCodeNumber:D5}";
        }
    }
}
