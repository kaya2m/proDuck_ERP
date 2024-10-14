using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proDuck.Application.Features.Commands.Customer.CreateCustomer;
using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Features.Commands.ProductCard.ProductCard.DeleteProductCard;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;

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
        try
        {
            var customerInfo =
                _customerReadRepository.GetByIdAsync(request.id).Result;
            if (customerInfo == null)
            {
                return new DeleteCustomerCommandResponse()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Customer not found",
                    IsSuccessful = false
                };
            }
            else
            {
                customerInfo.Status = false;
                _costumerWriteRepository.Update(customerInfo);
               await _costumerWriteRepository.SaveChangesAsync();
                return new DeleteCustomerCommandResponse()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Customer deleted successfully",
                    IsSuccessful = true
                };
            }
        }
        catch (Exception ex)
        {
            return new DeleteCustomerCommandResponse()
            {
                StatusCode = ex.HResult,
                Message = ex.Message,
                IsSuccessful = false
            };
        }

    }
}
