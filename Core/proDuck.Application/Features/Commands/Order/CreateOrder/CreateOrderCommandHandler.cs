using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Commands.Customer.CreateCustomer;
using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Repositories.OrderInterface;

namespace proDuck.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;
    public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order =await _orderWriteRepository.AddAsync(new()
        {
            //ProductId =request.ProductId,
            //OrderName = request.OrderName,
            OrderNumber =await GenerateOrderNumberAsync(request.CustomerCode),
            CustomerId = request.CustomerId,
            CustomerCode = request.CustomerCode,
            PaymentMethod = request.PaymentMethod,
            SubPaymentMethod = request.SubPaymentMethod,
            SalesRepresentative = request.SalesRepresentative,
            ContactPerson = request.ContactPerson,
            SalesType = request.SalesType,
            SubSalesType = request.SubSalesType,
            Description = request.Description,
            Amount = request.Amount,
            CustomerOrderNumber = request.CustomerOrderNumber,
            RepresentativeId = request.RepresentativeId
        });
        if (order)
        {
            await _orderWriteRepository.SaveChangesAsync();

            return new CreateOrderCommandResponse
            {
                Message = "Order created successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
            };
        }
        else
        {
            return new CreateOrderCommandResponse
            {
                Message = "Order creation failed",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
    }
    private async Task<string> GenerateOrderNumberAsync(string customerCode)
    {
        var order = await _orderReadRepository.GetAllAsync(false);

        var currentDate = DateTime.Now.ToString("yyyyMMdd"); 
        var orderNumber = $"ORD-{currentDate}-{customerCode}-{order.Count()}";

        return orderNumber;
    }
}
