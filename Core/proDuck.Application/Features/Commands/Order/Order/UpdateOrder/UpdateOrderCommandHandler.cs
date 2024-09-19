using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.Order;
using proDuck.Domain.Entities.Order;

namespace proDuck.Application.Features.Commands.Order.Order.UpdateOrder;

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
        try
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
            order.OrderName = request.OrderName;
            order.OrderNumber = request.OrderNumber;
            order.CustomerId = request.CustomerId;
            order.CustomerCode = request.CustomerCode;
            order.PaymentMethod = request.PaymentMethod;
            order.SubPaymentMethod = request.SubPaymentMethod;
            order.SalesRepresentative = request.SalesRepresentative;
            order.ContactPerson = request.ContactPerson;
            order.SalesType = request.SalesType;
            order.SubSalesType = request.SubSalesType;
            order.Description = request.Description;
            order.Amount = request.Amount;
            order.CustomerOrderNumber = request.CustomerOrderNumber;
            order.RepresentativeId = request.RepresentativeId;

            var result = _orderWriteRepository.Update(order);
            await _orderWriteRepository.SaveChangesAsync();
            return new UpdateOrderCommandResponse
            {
                Message = "Order updated successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status204NoContent,
            };
        }
        catch (Exception ex)
        {
            return new UpdateOrderCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult,
            };
        }
    }
}
