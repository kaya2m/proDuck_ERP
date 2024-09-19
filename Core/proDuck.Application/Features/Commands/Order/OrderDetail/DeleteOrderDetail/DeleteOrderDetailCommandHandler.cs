using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;

namespace proDuck.Application.Features.Commands.Order.OrderDetail.DeleteOrderDetail;

public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
{
    private readonly IOrderDetailReadRepository _orderDetailReadRepository;
    private readonly IOrderDetailWriteRepository _orderDetailWriteRepository;

    public DeleteOrderDetailCommandHandler(IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository)
    {
        _orderDetailReadRepository = orderDetailReadRepository;
        _orderDetailWriteRepository = orderDetailWriteRepository;
    }

    public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var orderDetail = await _orderDetailReadRepository.GetByIdAsync(request.id);
            if (orderDetail == null)
            {
                return new DeleteOrderDetailCommandResponse()
                {
                    IsSuccessful = false,
                    Message = "Order Detail not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                orderDetail.Status = false;
                _orderDetailWriteRepository.Update(orderDetail);
                await _orderDetailWriteRepository.SaveChangesAsync();
                return new DeleteOrderDetailCommandResponse()
                {
                    IsSuccessful = true,
                    Message = "Order Detail deleted successfully",
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }
        catch (Exception ex)
        {
            return new DeleteOrderDetailCommandResponse()
            {
                IsSuccessful = false,
                Message = ex.Message,
                StatusCode = ex.HResult
            };
        }

    }
}
