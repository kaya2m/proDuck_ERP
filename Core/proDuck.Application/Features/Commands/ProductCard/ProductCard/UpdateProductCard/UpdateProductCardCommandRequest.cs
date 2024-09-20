using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductCard.ProductCard.UpdateProductCard
{
    public class UpdateProductCardCommandRequest : IRequest<UpdateProductCardCommandResponse>
    {
        public Guid id { get; set; }
        public string ProductCode { get; set; }
        public string CustomerProductCode { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public Guid MachineId { get; set; }
        public Guid PalletId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public Guid RepresentativeId { get; set; }
        public string ProductName { get; set; }
        public string CustomProductName { get; set; }
        public string InvoiceDescription { get; set; }
        public string Description { get; set; }
        public string CustomerProductName { get; set; }
        public string InnerDimension { get; set; }
        public string OuterDimension { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public string MachineDescription { get; set; }
        public string CompletionDescription { get; set; }
        public string QualityDescription { get; set; }
        public string ShipmentDescription { get; set; }
        public bool LockStatus { get; set; }
        public bool ApprovalStatus { get; set; }
        public string ProcessStatus { get; set; }
        public decimal LoadingAmount { get; set; }
    }
}
