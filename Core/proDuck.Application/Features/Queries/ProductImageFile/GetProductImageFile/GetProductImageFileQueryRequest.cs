using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductImageFile.GetProductImageFile
{
    public class GetProductImageFileQueryRequest : IRequest<List<GetProductImageFileQueryResponse>>
    {
        public string id { get; set; }
    }
}
