//using proDuck.Application.Repositories.ProductInterface;
//using proDuck.Application.RequestParameters;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proDuck.Application.Features.Queries.Product.GetAllProduct
//{
//    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
//    {
//        readonly IProductReadRepository _productRead;
//        public GetAllProductQueryHandler(IProductReadRepository productRead)
//        {
//            _productRead = productRead;
//        }

//        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
//        {
//            var totalCount = _productRead.GetAll(false)
//              .Count();

//            var products = _productRead.GetAll(false)
//                .Select(p => new
//                {
//                    p.Id,
//                    p.Name,
//                    p.Price,
//                    p.Stock,
//                    p.CreateDate,
//                    p.UpdatedDate
//                }).Skip(request.Page * request.Size)
//                  .Take(request.Size).ToList();

//            return new()
//            {
//                Products = products,
//                TotalCount = totalCount
//            };
//        }
//    }
//}
