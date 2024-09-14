using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities.Order;

namespace proDuck.Application.Features.Commands.Order.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;

    public UpdateOrderCommandHandler(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
    {
        _orderReadRepository = orderReadRepository;
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        TBL_Order order = _orderReadRepository.GetByIdAsync(request.id).Result;

        if (order == null)
        {
            return new UpdateOrderCommandResponse
            {
                Message = "Order not found",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status404NotFound,
            };
        }
        //request.OrderName = order.OrderName;
        request.OrderNumber = order.OrderNumber;
        request.CustomerId = order.CustomerId;
        request.CustomerCode = order.CustomerCode;
        request.PaymentMethod = order.PaymentMethod;
        request.SubPaymentMethod = order.SubPaymentMethod;
        request.SalesRepresentative = order.SalesRepresentative;
        request.ContactPerson = order.ContactPerson;
        request.SalesType = order.SalesType;
        request.SubSalesType = order.SubSalesType;
        request.Description = order.Description;
        request.Amount = order.Amount;
        request.CustomerOrderNumber = order.CustomerOrderNumber;
        request.RepresentativeId = order.RepresentativeId;

        var result = _orderWriteRepository.Update(order);
        if (result)
        {
            await _orderWriteRepository.SaveChangesAsync();

            return new UpdateOrderCommandResponse
            {
                Message = "Order updated successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
            };
        }
        else
        {
            return new UpdateOrderCommandResponse
            {
                Message = "Order could not be updated",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
    }
}
