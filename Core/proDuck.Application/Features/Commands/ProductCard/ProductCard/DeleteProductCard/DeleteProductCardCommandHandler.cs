using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.ProductCard.DeleteProductCard
{
    public class DeleteProductCardCommandHandler : IRequestHandler<DeleteProductCardCommandRequest, DeleteProductCardCommandResponse>
    {
        private readonly IProductCardReadRepository _productCardReadRepository;
        private readonly IProductCardWriteRepository _productCardWriteRepository;

        public DeleteProductCardCommandHandler(IProductCardReadRepository productCardReadRepository, IProductCardWriteRepository productCardWriteRepository)
        {
            _productCardReadRepository = productCardReadRepository;
            _productCardWriteRepository = productCardWriteRepository;
        }

        public async Task<DeleteProductCardCommandResponse> Handle(DeleteProductCardCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productCard = await _productCardReadRepository.GetByIdAsync(request.id);
                if (productCard == null)
                {
                    return new DeleteProductCardCommandResponse()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "Product card not found",
                        IsSuccessful = false
                    };
                }
                else
                {
                    productCard.Status = false;
                    _productCardWriteRepository.Update(productCard);
                    await _productCardWriteRepository.SaveChangesAsync();
                    return new DeleteProductCardCommandResponse()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Product card deleted successfully",
                        IsSuccessful = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteProductCardCommandResponse()
                {
                    StatusCode = ex.HResult,
                    Message = ex.Message,
                    IsSuccessful = false
                };
            }
           
        }
    }
}
