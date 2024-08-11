using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.UpdateProductCard
{
    public class UpdateProductCardCommandHandler : IRequestHandler<UpdateProductCardCommandRequest, UpdateProductCardCommandResponse>
    {
        public Task<UpdateProductCardCommandResponse> Handle(UpdateProductCardCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
