﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Offer.Offer.DeleteOffer
{
    public class DeleteOfferCommandRequest : IRequest<DeleteOfferCommandResponse>
    {
        public Guid id { get; set; }
    }
}
