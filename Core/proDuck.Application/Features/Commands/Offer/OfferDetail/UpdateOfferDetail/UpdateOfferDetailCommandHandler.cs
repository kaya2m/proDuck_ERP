using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.UpdateOfferDetail
{
    public class UpdateOfferDetailCommandHandler : IRequestHandler<UpdateOfferDetailCommandRequest, UpdateOfferDetailCommandResponse>
    {
        public Task<UpdateOfferDetailCommandResponse> Handle(UpdateOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
