﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.OfferDetail.DeleteOfferDetail
{
    public class DeleteOfferDetailCommandRequest : IRequest<DeleteOfferDetailCommandResponse>
    {
        public Guid id { get; set; }
    }
}
