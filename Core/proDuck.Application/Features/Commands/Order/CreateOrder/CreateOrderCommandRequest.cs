using MediatR;

namespace proDuck.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public string OrderName { get; set; }
    public string OrderNumber { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public string CustomerCode { get; set; }
    public string PaymentMethod { get; set; }
    public string SubPaymentMethod { get; set; }
    public string SalesRepresentative { get; set; }
    public string ContactPerson { get; set; }
    public string SalesType { get; set; }
    public string SubSalesType { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string CustomerOrderNumber { get; set; }
    public Guid RepresentativeId { get; set; }
}
