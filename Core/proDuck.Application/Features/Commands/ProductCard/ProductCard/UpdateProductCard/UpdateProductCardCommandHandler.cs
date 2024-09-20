using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
namespace proDuck.Application.Features.Commands.ProductCard.ProductCard.UpdateProductCard;

public class UpdateProductCardCommandHandler : IRequestHandler<UpdateProductCardCommandRequest, UpdateProductCardCommandResponse>
{
    private readonly IProductCardReadRepository _productCardReadRepository;
    private readonly IProductCardWriteRepository _productCardWriteRepository;

    public UpdateProductCardCommandHandler(IProductCardReadRepository productCardReadRepository, IProductCardWriteRepository productCardWriteRepository)
    {
        _productCardReadRepository = productCardReadRepository;
        _productCardWriteRepository = productCardWriteRepository;
    }

    public async Task<UpdateProductCardCommandResponse> Handle(UpdateProductCardCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var productCard = await _productCardReadRepository.GetByIdAsync(request.id);
            if (productCard == null)
            {
                return new UpdateProductCardCommandResponse()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Product card not found",
                    IsSuccessful = false
                };
            }
            else
            {
                productCard.ProductCode = request.ProductCode;
                productCard.CustomerProductCode = request.CustomerProductCode;
                productCard.CustomerId = request.CustomerId;
                productCard.ModelId = request.ModelId;
                productCard.MachineId = request.MachineId;
                productCard.PalletId = request.PalletId;
                productCard.VehicleTypeId = request.VehicleTypeId;
                productCard.RepresentativeId = request.RepresentativeId;
                productCard.ProductName = request.ProductName;
                productCard.CustomProductName = request.CustomProductName;
                productCard.InvoiceDescription = request.InvoiceDescription;
                productCard.Description = request.Description;
                productCard.CustomerProductName = request.CustomerProductName;
                productCard.InnerDimension = request.InnerDimension;
                productCard.OuterDimension = request.OuterDimension;
                productCard.Width = request.Width;
                productCard.Length = request.Length;
                productCard.Height = request.Height;
                productCard.MachineDescription = request.MachineDescription;
                productCard.CompletionDescription = request.CompletionDescription;
                productCard.QualityDescription = request.QualityDescription;
                productCard.ShipmentDescription = request.ShipmentDescription;
                productCard.LockStatus = request.LockStatus;
                productCard.ApprovalStatus = request.ApprovalStatus;
                productCard.ProcessStatus = request.ProcessStatus;
                productCard.LoadingAmount = request.LoadingAmount;
            }
            _productCardWriteRepository.Update(productCard);
            await _productCardWriteRepository.SaveChangesAsync();
            return new UpdateProductCardCommandResponse()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Product card updated successfully",
                IsSuccessful = true
            };
        }
        catch (Exception ex)
        {
            return new UpdateProductCardCommandResponse()
            {
                StatusCode = ex.HResult,
                Message = ex.Message,
                IsSuccessful = false
            };
        }

    }
}
