using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Offer.Meeting.GetAllMeeting;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.Offer.GetAllOffer
{
    public class GetAllOfferQueryHandler : IRequestHandler<GetAllOfferQueryRequest, GetAllOfferQueryResponse>
    {
        private readonly IOfferReadRepository _offerReadRepository;

        public GetAllOfferQueryHandler(IOfferReadRepository offerReadRepository)
        {
            _offerReadRepository = offerReadRepository;
        }

        public async Task<GetAllOfferQueryResponse> Handle(GetAllOfferQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var offers = _offerReadRepository.GetAll(false);

                var totalCount = await offers.CountAsync();

                var offerFilters = await offers
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllOfferQueryResponse
                {
                    Data = offers,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new GetAllOfferQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
