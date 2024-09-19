using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;

namespace proDuck.Application.Features.Commands.Order.OrderDetail.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;
        private readonly IOrderDetailWriteRepository _orderDetailWriteRepository;

        public UpdateOrderDetailCommandHandler(IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var oderDetail = await _orderDetailReadRepository.GetByIdAsync(request.id);
                if (oderDetail == null)
                {
                    return new UpdateOrderDetailCommandResponse()
                    {
                        IsSuccessful = false,
                        Message = "Order Detail not found",
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                else
                {
                    oderDetail.OrderSequence = request.OrderSequence;
                    oderDetail.CustomerId = request.CustomerId;
                    oderDetail.OrderId = request.OrderId;
                    oderDetail.OfferId = request.OfferId;
                    oderDetail.OfferDetailId = request.OfferDetailId;
                    oderDetail.CustomerOrderNumber = request.CustomerOrderNumber;
                    oderDetail.SpecialCode = request.SpecialCode;
                    oderDetail.ProductCardId = request.ProductCardId;
                    oderDetail.Price = request.Price;
                    oderDetail.CurrencyPrice = request.CurrencyPrice;
                    oderDetail.CurrencyType = request.CurrencyType;
                    oderDetail.ExchangeRate = request.ExchangeRate;
                    oderDetail.FreightAmount = request.FreightAmount;
                    oderDetail.FreightUnitPrice = request.FreightUnitPrice;
                    oderDetail.FreightIncludedPrice = request.FreightIncludedPrice;
                    oderDetail.Quantity = request.Quantity;
                    oderDetail.ProductionQuantity = request.ProductionQuantity;
                    oderDetail.LoadingQuantity = request.LoadingQuantity;
                    oderDetail.PalletCount = request.PalletCount;
                    oderDetail.Amount = request.Amount;
                    oderDetail.UnitOfMeasureId = request.UnitOfMeasureId;
                    oderDetail.ProductionDeadline = request.ProductionDeadline;
                    oderDetail.DeliveryDeadline = request.DeliveryDeadline;
                    oderDetail.DeliveryTime = request.DeliveryTime;
                    oderDetail.VehicleType = request.VehicleType;
                    oderDetail.ShippingAddressId = request.ShippingAddressId;
                    oderDetail.FreightUnitCost = request.FreightUnitCost;
                    oderDetail.ApprovalStatus = request.ApprovalStatus;
                    oderDetail.ProductUnitPrice = request.ProductUnitPrice;
                    oderDetail.ProductSalesUnitPrice = request.ProductSalesUnitPrice;
                    oderDetail.Rate = request.Rate;
                }
                _orderDetailWriteRepository.Update(oderDetail);
                await _orderDetailWriteRepository.SaveChangesAsync();
                return new UpdateOrderDetailCommandResponse()
                {
                    IsSuccessful = true,
                    Message = "Order Detail updated successfully",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new UpdateOrderDetailCommandResponse()
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    StatusCode = ex.HResult
                };
            }
           
        }
    }
}
