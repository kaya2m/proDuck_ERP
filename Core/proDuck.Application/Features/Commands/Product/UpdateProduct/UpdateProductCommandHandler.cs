//using proDuck.Application.Repositories.ProductInterface;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proDuck.Application.Features.Commands.Product.UpdateProduct
//{
//    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
//    {
//        readonly IProductWriteRepository _productWriteRepository;
//        readonly IProductReadRepository __productReadRepository;

//        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
//        {
//            __productReadRepository = productReadRepository;
//            _productWriteRepository = productWriteRepository;
//        }

//        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
//        {
//            proDuck.Domain.Entities.Product product = await __productReadRepository.GetByIdAsync(request.Id);
//            product.Stock = request.Stock;
//            product.Price = request.Price;
//            product.Name = request.Name;
//            await _productWriteRepository.SaveAsync();
//            return new();
//        }
//    }
//}
