using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.CreateOfferDetail
{
    public class CreateOfferDetailCommandHandler : IRequestHandler<CreateOfferDetailCommandRequest, CreateOfferDetailCommandResponse>
    {
        public Task<CreateOfferDetailCommandResponse> Handle(CreateOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
