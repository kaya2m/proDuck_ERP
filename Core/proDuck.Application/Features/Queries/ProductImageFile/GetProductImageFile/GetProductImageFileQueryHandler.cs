//using proDuck.Application.Repositories.ProductInterface;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proDuck.Application.Features.Queries.ProductImageFile.GetProductImageFile
//{
//    public class GetProductImageFileQueryHandler : IRequestHandler<GetProductImageFileQueryRequest, List<GetProductImageFileQueryResponse>>
//    {
//        readonly IProductReadRepository _productReadRepository;
//        readonly IConfiguration configuration;

//        public GetProductImageFileQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
//        {
//            _productReadRepository = productReadRepository;
//            this.configuration = configuration;
//        }

//        public async Task<List<GetProductImageFileQueryResponse>> Handle(GetProductImageFileQueryRequest request, CancellationToken cancellationToken)
//        {
//           proDuck.Domain.Entities.Product product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
//                    .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.id));
//            return new(product.ProductImageFiles.Select(p => new GetProductImageFileQueryResponse
//            {
//                Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
//                FileName=  p.FileName,
//                id= p.Id
//            }));
//        }
//    }
//}
