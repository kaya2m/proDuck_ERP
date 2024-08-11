using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.DeleteOfferDetail
{
    public class DeleteOfferDetailCommandHandler : IRequestHandler<DeleteOfferDetailCommandRequest, DeleteOfferDetailCommandResponse>
    {
        public Task<DeleteOfferDetailCommandResponse> Handle(DeleteOfferDetailCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
