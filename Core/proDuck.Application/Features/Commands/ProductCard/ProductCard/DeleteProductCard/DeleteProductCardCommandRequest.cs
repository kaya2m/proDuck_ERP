using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.ProductCard.DeleteProductCard
{
    public class DeleteProductCardCommandRequest : IRequest<DeleteProductCardCommandResponse>
    {
        public Guid id { get; set; }
    }
}
