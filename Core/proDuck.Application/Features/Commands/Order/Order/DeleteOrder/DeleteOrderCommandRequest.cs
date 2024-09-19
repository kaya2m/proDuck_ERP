using MediatR;

namespace proDuck.Application.Features.Commands.Order.Order.DeleteOrder;

public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
{
    public Guid id { get; set; }
}
