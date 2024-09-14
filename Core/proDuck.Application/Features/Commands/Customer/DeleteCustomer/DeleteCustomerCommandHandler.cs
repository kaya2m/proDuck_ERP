using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.Features.Commands.Customer.CreateCustomer;
using proDuck.Application.Repositories.CustomerInterface;

namespace proDuck.Application.Features.Commands.Customer.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
{
    private readonly ICustomerWriteRepository _costumerWriteRepository;
    private readonly ICustomerReadRepository _customerReadRepository;

    public DeleteCustomerCommandHandler(ICustomerWriteRepository costumerWriteRepository, ICustomerReadRepository customerReadRepository)
    {
        _costumerWriteRepository = costumerWriteRepository;
        _customerReadRepository = customerReadRepository;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customerInfo =
                _customerReadRepository.GetByIdAsync(request.id).Result;
        customerInfo.Status = false;
         _costumerWriteRepository.Update(customerInfo);
        var customer = await _costumerWriteRepository.SaveChangesAsync();
        if (customer == 200)
        {
          
            return new DeleteCustomerCommandResponse
            {
                Message = "Customer deleted successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
            };

        }
        else
        {
            return new DeleteCustomerCommandResponse
            {
                Message = "Customer could not be deleted",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
    }
}