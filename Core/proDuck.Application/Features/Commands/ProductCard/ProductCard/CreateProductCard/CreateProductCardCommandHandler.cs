using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.ProductCard.CreateProductCard
{
    public class CreateProductCardCommandHandler : IRequestHandler<CreateProductCardCommandRequest, CreateProductCardCommandResponse>
    {
        private readonly IProductCardWriteRepository _productCardWriteRepository;

        public CreateProductCardCommandHandler(IProductCardWriteRepository productCardWriteRepository)
        {
            _productCardWriteRepository = productCardWriteRepository;
        }

        public async Task<CreateProductCardCommandResponse> Handle(CreateProductCardCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productCard = await _productCardWriteRepository.AddAsync(new()
                {
                    ProductCode = request.ProductCode,
                    CustomerProductCode = request.CustomerProductCode,
                    CustomerId = request.CustomerId,
                    ModelId = request.ModelId,
                    MachineId = request.MachineId,
                    PalletId = request.PalletId,
                    VehicleTypeId = request.VehicleTypeId,
                    RepresentativeId = request.RepresentativeId,
                    ProductName = request.ProductName,
                    CustomProductName = request.CustomProductName,
                    InvoiceDescription = request.InvoiceDescription,
                    Description = request.Description,
                    CustomerProductName = request.CustomerProductName,
                    InnerDimension = request.InnerDimension,
                    OuterDimension = request.OuterDimension,
                    Width = request.Width,
                    Length = request.Length,
                    Height = request.Height,
                    MachineDescription = request.MachineDescription,
                    CompletionDescription = request.CompletionDescription,
                    QualityDescription = request.QualityDescription,
                    ShipmentDescription = request.ShipmentDescription,
                    LockStatus = request.LockStatus,
                    ApprovalStatus = request.ApprovalStatus,
                    ProcessStatus = request.ProcessStatus,
                    LoadingAmount = request.LoadingAmount
,
                });
                await _productCardWriteRepository.SaveChangesAsync();
                return new CreateProductCardCommandResponse()
                {
                    StatusCode = StatusCodes.Status201Created,
                    IsSuccessful = true,
                    Message = "Product card created successfully",
                };
            }
            catch (Exception ex)
            {
                return new CreateProductCardCommandResponse()
                {
                    StatusCode =ex.HResult,
                    IsSuccessful = false,
                    Message =ex.Message,
                };
            }

        }
    }
}
