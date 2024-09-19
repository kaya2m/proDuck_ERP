using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.CreateOfferDetail
{
    public class CreateOfferDetailCommandHandler : IRequestHandler<CreateOfferDetailCommandRequest, CreateOfferDetailCommandResponse>
    {
        private readonly IOfferDetailWriteRepository _offerDetailWriteRepository;
        private readonly IOfferReadRepository _offerReadRepository;
        public CreateOfferDetailCommandHandler(IOfferDetailWriteRepository offerDetailWriteRepository, IOfferReadRepository offerReadRepository)
        {
            _offerDetailWriteRepository = offerDetailWriteRepository;
            _offerReadRepository = offerReadRepository;
        }

        public async Task<CreateOfferDetailCommandResponse> Handle(CreateOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var offer = await _offerReadRepository.GetByIdAsync(request.OfferId);
                if (offer == null)
                {
                    return new CreateOfferDetailCommandResponse
                    {
                        Message = "Offer not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    var offerDetail = await _offerDetailWriteRepository.AddAsync(new()
                    {
                        SpecialCode = request.SpecialCode,
                        UnitPrice = request.UnitPrice,
                        Amount = request.Amount,
                        Discount = request.Discount,
                        DiscountedAmount = request.DiscountedAmount,
                        Quantity = request.Quantity,
                        Unit = request.Unit,
                        DeliveryDate = request.DeliveryDate,
                        Description = request.Description,
                        Image = request.Image,
                        Date = request.Date,
                        OfferId = request.OfferId,
                        ProductCardId = request.ProductCardId
                    });
                    await _offerDetailWriteRepository.SaveChangesAsync();
                    return new CreateOfferDetailCommandResponse
                    {
                        Data = offerDetail,
                        Message = "Offer detail created successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status201Created,
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateOfferDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                };
            }  
        }
    }
}
