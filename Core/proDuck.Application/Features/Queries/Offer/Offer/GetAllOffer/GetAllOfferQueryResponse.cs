using proDuck.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.Offer.GetAllOffer
{
    public class GetAllOfferQueryResponse : ResponseDto<GetAllOfferQueryResponse>
    {
        public int TotalCount { get; set; }
    }
}
