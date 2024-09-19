using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.Order;
namespace proDuck.Application.Features.Commands.Order.Order.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;

    public DeleteOrderCommandHandler(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
    {
        _orderReadRepository = orderReadRepository;
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var orderInfo = _orderReadRepository.GetByIdAsync(request.id).Result;
            orderInfo.Status = false;
            _orderWriteRepository.Update(orderInfo);
            var order = await _orderWriteRepository.SaveChangesAsync();
            return new DeleteOrderCommandResponse
            {
                Message = "Order deleted successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status204NoContent
            };
        }
        catch (Exception ex)
        {
            return new DeleteOrderCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }
    }
}
