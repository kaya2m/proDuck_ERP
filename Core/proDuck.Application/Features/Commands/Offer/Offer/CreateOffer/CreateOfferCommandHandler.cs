using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using System;


namespace proDuck.Application.Features.Commands.Offer.Offer.CreateOffer;

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommandRequest, CreateOfferCommandResponse>
{
    private readonly IOfferWriteRepository _offerWriteRepository;

    public CreateOfferCommandHandler(IOfferWriteRepository offerWriteRepository)
    {
        _offerWriteRepository = offerWriteRepository;
    }

    public async Task<CreateOfferCommandResponse> Handle(CreateOfferCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var offer = await _offerWriteRepository.AddAsync(new()
            {
                Type = request.Type,
                OfferNumber = request.OfferNumber,
                CompanyNumber = request.CompanyNumber,
                PaymentMethod = request.PaymentMethod,
                PaymentTerm = request.PaymentTerm,
                ContactPerson = request.ContactPerson,
                Description = request.Description,
                Unit = request.Unit,
                TotalAmount = request.TotalAmount,
                DiscountedTotalAmount = request.DiscountedTotalAmount,
                Date = request.Date,
                CustomerId = request.CustomerId,
                OrderId = request.OrderId,
                ShippingAddressId = request.ShippingAddressId,
                MeetingId = request.MeetingId,
                SalesRepresentativeId = request.SalesRepresentativeId,
                VehicleTypeId = request.VehicleTypeId,
                PaymentTypeId = request.PaymentTypeId,
                SalesTypeId = request.SalesTypeId
            });
            await _offerWriteRepository.SaveChangesAsync();
            return new CreateOfferCommandResponse
            {
                Data = offer,
                Message = "Offer created successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
            };
        }
        catch (Exception ex)
        {
            return new CreateOfferCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult,
            };
        }
        

    }
}
