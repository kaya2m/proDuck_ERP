//using proDuck.Application.Repositories.ProductInterface;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace proDuck.Application.Features.Commands.Product.DeleteProduct
//{
//    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
//    {
//        readonly IProductReadRepository _productReadeRepository;
//        readonly IProductWriteRepository _productWriteRepository;

//        public DeleteProductCommandHandler(IProductReadRepository productReadeRepository, IProductWriteRepository productWriteRepository)
//        {
//            _productReadeRepository = productReadeRepository;
//            _productWriteRepository = productWriteRepository;
//        }

//        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
//        {
//            await _productWriteRepository.Remove(request.id);
//            await _productWriteRepository.SaveChangesAsync();
//            return new();
//        }
//    }
//}
