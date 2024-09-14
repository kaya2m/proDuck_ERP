using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequest :IRequest<DeleteProductCommandResponse>
    {
        public Guid id { get; set; }
    }
}
