using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface;
namespace proDuck.Application.Features.Commands.Order.DeleteOrder;

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
        var orderInfo = _orderReadRepository.GetByIdAsync(request.id).Result;
        orderInfo.Status = false;
        _orderWriteRepository.Update(orderInfo);
        var order = await _orderWriteRepository.SaveChangesAsync();
        if (order == 200)
        {
            return new DeleteOrderCommandResponse
            {
                Message = "Order deleted successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
        else
        {
            return new DeleteOrderCommandResponse
            {
                Message = "Order could not be deleted",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
