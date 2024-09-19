using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Offer.Meeting.GetByIdMetting;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.OfferDetail.GetByIdOfferDetail
{
    public class GetByIdOfferDetailQueryHandler : IRequestHandler<GetByIdOfferDetailQueryRequest, GetByIdOfferDetailQueryResponse>
    {
        private readonly IOfferDetailReadRepository _offerDetailReadRepository;

        public GetByIdOfferDetailQueryHandler(IOfferDetailReadRepository offerDetailReadRepository)
        {
            _offerDetailReadRepository = offerDetailReadRepository;
        }

        public async Task<GetByIdOfferDetailQueryResponse> Handle(GetByIdOfferDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var offerDetail = await _offerDetailReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = offerDetail != null;

            return new GetByIdOfferDetailQueryResponse
            {
                Data = offerDetail,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
