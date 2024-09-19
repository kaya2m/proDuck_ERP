using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.Offer.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommandRequest, DeleteOfferCommandResponse>
    {
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IOfferWriteRepository _offerWriteRepository;

        public DeleteOfferCommandHandler(IOfferReadRepository offerReadRepository, IOfferWriteRepository offerWriteRepository)
        {
            _offerReadRepository = offerReadRepository;
            _offerWriteRepository = offerWriteRepository;
        }

        public async Task<DeleteOfferCommandResponse> Handle(DeleteOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var offer = await _offerReadRepository.GetByIdAsync(request.id);
                if (offer == null)
                {
                    return new DeleteOfferCommandResponse
                    {
                        Message = "Offer not found",
                        IsSuccessful = false
                    };
                }
                else
                {
                    offer.Status = false;
                    _offerWriteRepository.Update(offer);
                    await _offerWriteRepository.SaveChangesAsync();
                    return new DeleteOfferCommandResponse
                    {
                        Message = "Offer deleted successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status204NoContent
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteOfferCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
