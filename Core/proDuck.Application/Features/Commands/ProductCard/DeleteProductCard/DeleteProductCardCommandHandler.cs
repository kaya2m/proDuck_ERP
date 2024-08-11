using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.DeleteProductCard
{
    public class DeleteProductCardCommandHandler : IRequestHandler<DeleteProductCardCommandRequest, DeleteProductCardCommandResponse>
    {
        public Task<DeleteProductCardCommandResponse> Handle(DeleteProductCardCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
