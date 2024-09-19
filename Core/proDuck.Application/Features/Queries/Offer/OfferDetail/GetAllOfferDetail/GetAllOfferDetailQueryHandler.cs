using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Offer.Meeting.GetAllMeeting;
using proDuck.Application.Repositories.OfferInterfaces.MeetingInterface;
using proDuck.Application.Repositories.OfferInterfaces.OfferDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.OfferDetail.GetAllOfferDetail
{
    public class GetAllOfferDetailQueryHandler : IRequestHandler<GetAllOfferDetailQueryRequest, GetAllOfferDetailQueryResponse>
    {
        private readonly IOfferDetailReadRepository _offerDetailReadRepository;

        public GetAllOfferDetailQueryHandler(IOfferDetailReadRepository offerDetailReadRepository)
        {
            _offerDetailReadRepository = offerDetailReadRepository;
        }

        public async Task<GetAllOfferDetailQueryResponse> Handle(GetAllOfferDetailQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var offerDetails = _offerDetailReadRepository.GetAll(false);

                var totalCount = await offerDetails.CountAsync();

                var offerDetailFilters = await offerDetails
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllOfferDetailQueryResponse
                {
                    Data = offerDetails,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new GetAllOfferDetailQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
