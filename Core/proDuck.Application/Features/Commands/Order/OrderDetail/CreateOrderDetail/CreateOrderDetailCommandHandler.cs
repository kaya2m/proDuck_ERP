using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Order.OrderDetail.CreateOrderDetail
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        private readonly IOrderDetailWriteRepository _orderDetailWriteRepository;

        public CreateOrderDetailCommandHandler(IOrderDetailWriteRepository orderDetailWriteRepository)
        {
            _orderDetailWriteRepository = orderDetailWriteRepository;
        }

        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderDetail = await _orderDetailWriteRepository.AddAsync(new()
                {
                    OrderSequence = request.OrderSequence,
                    CustomerId = request.CustomerId,
                    OrderId = request.OrderId,
                    OfferId = request.OfferId,
                    OfferDetailId = request.OfferDetailId,
                    CustomerOrderNumber = request.CustomerOrderNumber,
                    SpecialCode = request.SpecialCode,
                    ProductCardId = request.ProductCardId,
                    Price = request.Price,
                    CurrencyPrice = request.CurrencyPrice,
                    CurrencyType = request.CurrencyType,
                    ExchangeRate = request.ExchangeRate,
                    FreightAmount = request.FreightAmount,
                    FreightUnitPrice = request.FreightUnitPrice,
                    FreightIncludedPrice = request.FreightIncludedPrice,
                    Quantity = request.Quantity,
                    ProductionQuantity = request.ProductionQuantity,
                    LoadingQuantity = request.LoadingQuantity,
                    PalletCount = request.PalletCount,
                    Amount = request.Amount,
                    UnitOfMeasureId = request.UnitOfMeasureId,
                    ProductionDeadline = request.ProductionDeadline,
                    DeliveryDeadline = request.DeliveryDeadline,
                    DeliveryTime = request.DeliveryTime,
                    VehicleType = request.VehicleType,
                    ShippingAddressId = request.ShippingAddressId,
                    FreightUnitCost = request.FreightUnitCost,
                    ApprovalStatus = request.ApprovalStatus,
                    ProductUnitPrice = request.ProductUnitPrice,
                    ProductSalesUnitPrice = request.ProductSalesUnitPrice,
                    Rate = request.Rate

                });
                await _orderDetailWriteRepository.SaveChangesAsync();
                return new CreateOrderDetailCommandResponse()
                {
                    Message = "OrderDetail created successfully",
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status201Created

                };
            }
            catch (Exception ex)
            {
                return new CreateOrderDetailCommandResponse()
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
           
        }
    }
}
