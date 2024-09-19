using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.UpdateOfferDetail
{
    public class UpdateOfferDetailCommandHandler : IRequestHandler<UpdateOfferDetailCommandRequest, UpdateOfferDetailCommandResponse>
    {
        private readonly IOfferDetailReadRepository _offerDetailReadRepository;
        private readonly IOfferDetailWriteRepository _offerDetailWriteRepository;

        public UpdateOfferDetailCommandHandler(IOfferDetailReadRepository offerDetailReadRepository, IOfferDetailWriteRepository offerDetailWriteRepository)
        {
            _offerDetailReadRepository = offerDetailReadRepository;
            _offerDetailWriteRepository = offerDetailWriteRepository;
        }

        public async Task<UpdateOfferDetailCommandResponse> Handle(UpdateOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var offerDetail = await _offerDetailReadRepository.GetByIdAsync(request.id);

                if (offerDetail == null)
                {
                    return new UpdateOfferDetailCommandResponse
                    {
                        Message = "Offer Detail not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    offerDetail.SpecialCode = request.SpecialCode;
                    offerDetail.UnitPrice = request.UnitPrice;
                    offerDetail.Amount = request.Amount;
                    offerDetail.Discount = request.Discount;
                    offerDetail.DiscountedAmount = request.DiscountedAmount;
                    offerDetail.Quantity = request.Quantity;
                    offerDetail.Unit = request.Unit;
                    offerDetail.DeliveryDate = request.DeliveryDate;
                    offerDetail.Description = request.Description;
                    offerDetail.Image = request.Image;
                    offerDetail.Date = request.Date;
                    offerDetail.OfferId = request.OfferId;
                    offerDetail.ProductCardId = request.ProductCardId;

                    _offerDetailWriteRepository.Update(offerDetail);
                    await _offerDetailWriteRepository.SaveChangesAsync();
                    return new UpdateOfferDetailCommandResponse
                    {
                        Message = "Offer detail updated successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status200OK
                    };

                }
            }
            catch (Exception ex)
            {
                return new UpdateOfferDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
            
        }
    }
}
