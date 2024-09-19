using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Commands.Customer.CreateCustomer;
using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Repositories.OrderInterface.Order;

namespace proDuck.Application.Features.Commands.Order.Order.CreateOrder;

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
        try
        {
            var order = await _orderWriteRepository.AddAsync(new()
            {

                OrderNumber = await GenerateOrderNumberAsync(request.CustomerCode),
                StockNumber = GenerateStockNumber(),
                SerialNumber = GenerateSerialNumber(),
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

            await _orderWriteRepository.SaveChangesAsync();
            return new CreateOrderCommandResponse
            {
                Data = order,
                Message = "Order created successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
            };
        }
        catch (Exception ex)
        {
            return new CreateOrderCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult,
            };
        }
    }
    private async Task<string> GenerateOrderNumberAsync(string customerCode)
    {
        var order = await _orderReadRepository.GetWhereAsync(o => o.CustomerCode == customerCode);

        var currentDate = DateTime.Now.ToString("yyyyMMdd");
        var orderNumber = $"ORD-{currentDate}-{customerCode}-{order.Count()}";

        return orderNumber;
    }
    private string GenerateStockNumber()
    {
        var currentDate = DateTime.Now.ToString("yyyyMMdd");
        var random = new Random();
        var uniqueNumber = random.Next(100, 999);

        return $"STC-{currentDate}-{"PD"}-{uniqueNumber}";
    }
    private string GenerateSerialNumber()
    {
        var random = new Random();
        var uniqueId = random.Next(100000, 999999);

        return $"{DateTime.Now.ToString("dd")}-{DateTime.Now.ToString("yyyy")}-{uniqueId}";
    }
}
