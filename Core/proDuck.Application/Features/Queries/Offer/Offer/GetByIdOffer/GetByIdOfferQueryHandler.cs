using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Offer.Meeting.GetByIdMetting;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.Offer.GetByIdOffer
{
    public class GetByIdOfferQueryHandler : IRequestHandler<GetByIdOfferQueryRequest, GetByIdOfferQueryResponse>
    {
        private readonly IOfferReadRepository _offerReadRepository;

        public GetByIdOfferQueryHandler(IOfferReadRepository offerReadRepository)
        {
            _offerReadRepository = offerReadRepository;
        }

        public async Task<GetByIdOfferQueryResponse> Handle(GetByIdOfferQueryRequest request, CancellationToken cancellationToken)
        {
            var offer = await _offerReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = offer != null;

            return new GetByIdOfferQueryResponse
            {
                Data = offer,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
