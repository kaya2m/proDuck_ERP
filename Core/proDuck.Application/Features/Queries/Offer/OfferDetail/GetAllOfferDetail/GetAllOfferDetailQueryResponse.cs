using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.OfferDetail.GetAllOfferDetail
{
    public class GetAllOfferDetailQueryResponse : ResponseDto<GetAllOfferDetailQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
