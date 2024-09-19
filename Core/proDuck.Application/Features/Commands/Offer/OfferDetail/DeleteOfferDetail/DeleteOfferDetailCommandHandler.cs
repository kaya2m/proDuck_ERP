using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.DeleteOfferDetail
{
    public class DeleteOfferDetailCommandHandler : IRequestHandler<DeleteOfferDetailCommandRequest, DeleteOfferDetailCommandResponse>
    {
        private readonly IOfferDetailReadRepository _offerDetailReadRepository;
        private readonly IOfferDetailWriteRepository _offerDetailWriteRepository;

        public DeleteOfferDetailCommandHandler(IOfferDetailWriteRepository offerDetailWriteRepository)
        {
            _offerDetailWriteRepository = offerDetailWriteRepository;
        }

        public async Task<DeleteOfferDetailCommandResponse> Handle(DeleteOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var offerDetail = await _offerDetailReadRepository.GetByIdAsync(request.id);
                if (offerDetail == null)
                {
                    return new DeleteOfferDetailCommandResponse
                    {
                        Message = "Offer Detail not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    offerDetail.Status = false;
                    _offerDetailWriteRepository.Update(offerDetail);
                    await _offerDetailWriteRepository.SaveChangesAsync();
                    return new DeleteOfferDetailCommandResponse
                    {
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status200OK
                    };
                }

            }
            catch (Exception ex)
            {
                return new DeleteOfferDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
