using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.Repositories.CustomerInterface;

namespace proDuck.Application.Features.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        public UpdateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

            var customer = 
                _customerReadRepository.GetByIdAsync(request.Id).Result;

            if (customer == null) {
                return new UpdateCustomerCommandResponse
                {
                    Message = "Customer not found",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                customer.Name = request.Name;
                customer.Email = request.Email;
                customer.Address = request.Address;
                customer.ContactNumber = request.ContactNumber;
                customer.CountryId = request.CountryId;
                customer.CityId = request.CityId;
                customer.TownId = request.TownId;
                customer.CountryCode = request.CountryCode;
                customer.CompanyName = request.CompanyName;
                customer.ContactNumber2 = request.ContactNumber2;
                customer.Email2 = request.Email2;
                customer.Address2 = request.Address2;
                customer.PostCode = request.PostCode;
                customer.PaymentMethod = request.PaymentMethod;
                customer.TaxNumber = request.TaxNumber;
                customer.TaxOffice = request.TaxOffice;
                customer.Notes = request.Notes;
                 _customerWriteRepository.Update(customer);
                var result =await _customerWriteRepository.SaveChangesAsync();
                if (result == 200)
                {
                    return new UpdateCustomerCommandResponse
                    {
                        Message = "Customer updated successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new UpdateCustomerCommandResponse
                    {
                        Message = "Customer could not be updated",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
        }
    }
}
