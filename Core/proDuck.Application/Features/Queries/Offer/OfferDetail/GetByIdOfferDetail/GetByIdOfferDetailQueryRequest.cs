using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Offer.OfferDetail.GetByIdOfferDetail
{
    public class GetByIdOfferDetailQueryRequest : IRequest<GetByIdOfferDetailQueryResponse>
    {
        public Guid id { get; set; }
    }
}
