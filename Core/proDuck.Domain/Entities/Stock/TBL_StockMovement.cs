using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Identity;
using proDuck.Domain.Entities.Machine;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Stock
{
    [Table("stockmovement")]
    public class TBL_StockMovement : BaseEntity
    {
        public Guid MovementId { get; set; }
        public Guid ReturnId { get; set; }
        public string MovementType { get; set; }
        public Guid PreviousMovementId { get; set; }
        public string PreviousMovementType { get; set; }
        public DateTime PreviousMovementDate { get; set; }
        public Guid OrderDetailId { get; set; }
        public int OrderSequence { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Deadline { get; set; }
        public Guid ProductId { get; set; }
        public Guid MachineId { get; set; }
        public string BarcodeNumber { get; set; }
        public string PalletNumber { get; set; }
        public Guid PalletId { get; set; }
        public int PalletCount { get; set; }
        public decimal PalletVolume { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PalletPrice { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid ShippingBasketId { get; set; }
        public string ShippingStatus { get; set; }
        public Guid UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public Guid SalesRepresentativeId { get; set; }
        public bool IsSystemOutside { get; set; }
        public Guid SystemOutsideUserId { get; set; }

        // Navigation properties
        public TBL_Customer Customer { get; set; }
        public TBL_ProductCard ProductCard { get; set; }
        public TBL_Machine Machine { get; set; }
        public TBL_SalesRepresentative SalesRepresentative { get; set; }
        public TBL_Warehouse Warehouse { get; set; }
       
    }
}
