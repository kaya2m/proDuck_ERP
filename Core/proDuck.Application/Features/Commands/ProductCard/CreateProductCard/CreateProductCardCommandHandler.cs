using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.CreateProductCard
{
    public class CreateProductCardCommandHandler : IRequestHandler<CreateProductCardCommandRequest, CreateProductCardCommandResponse>
    {
        public Task<CreateProductCardCommandResponse> Handle(CreateProductCardCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
