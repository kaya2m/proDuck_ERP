using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace proDuck.Application.Features.Commands.Offer.Offer.UpdateOffer;

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommandRequest, UpdateOfferCommandResponse>
{
    private readonly IOfferReadRepository _offerReadRepository;
    private readonly IOfferWriteRepository _offerWriteRepository;

    public UpdateOfferCommandHandler(IOfferReadRepository offerReadRepository, IOfferWriteRepository offerWriteRepository)
    {
        _offerReadRepository = offerReadRepository;
        _offerWriteRepository = offerWriteRepository;
    }

    public async Task<UpdateOfferCommandResponse> Handle(UpdateOfferCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var offer = await _offerReadRepository.GetByIdAsync(request.id);
            if (offer == null)
            {
                return new UpdateOfferCommandResponse
                {
                    Message = "Offer not found",
                    IsSuccessful = false
                };
            }
            else
            {
                offer.Type = request.Type;
                offer.OfferNumber = request.OfferNumber;
                offer.CompanyNumber = request.CompanyNumber;
                offer.PaymentMethod = request.PaymentMethod;
                offer.PaymentTerm = request.PaymentTerm;
                offer.ContactPerson = request.ContactPerson;
                offer.Description = request.Description;
                offer.Unit = request.Unit;
                offer.TotalAmount = request.TotalAmount;
                offer.DiscountedTotalAmount = request.DiscountedTotalAmount;
                offer.Date = request.Date;
                offer.CustomerId = request.CustomerId;
                offer.OrderId = request.OrderId;
                offer.ShippingAddressId = request.ShippingAddressId;
                offer.MeetingId = request.MeetingId;
                offer.SalesRepresentativeId = request.SalesRepresentativeId;
                offer.VehicleTypeId = request.VehicleTypeId;
                offer.PaymentTypeId = request.PaymentTypeId;
                offer.SalesTypeId = request.SalesTypeId;

                _offerWriteRepository.Update(offer);
                await _offerWriteRepository.SaveChangesAsync();
                return new UpdateOfferCommandResponse
                {
                    Message = "Offer deleted successfully",
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
        }
        catch (Exception ex)
        {
            return new UpdateOfferCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }
        
    }
}
