//using proDuck.Application.Repositories.ProductInterface;
//using p = proDuck.Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proDuck.Application.Features.Queries.Product.GetByIdProduct
//{
//    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
//    {
//        readonly IProductReadRepository _productReadRepository;

//        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
//        {
//            _productReadRepository = productReadRepository;
//        }

//        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
//        {
//           //p.Product product = await _productReadRepository.GetByIdAsync(request.id, false);
//           // return new()
//           // {
//           //     Name = product.Name,
//           //     Price = product.Price,
//           //     Stock = product.Stock 
//           // };
//        }
//    }
//}
