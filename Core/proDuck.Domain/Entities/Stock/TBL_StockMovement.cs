using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Identity;
using proDuck.Domain.Entities.Machine;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Domain.Entities.SalesRepresentative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Domain.Entities.Stock
{
    public class TBL_StockMovement : BaseEntity
    {
        public int MovementId { get; set; }
        public int ReturnId { get; set; }
        public string MovementType { get; set; }
        public int PreviousMovementId { get; set; }
        public string PreviousMovementType { get; set; }
        public DateTime PreviousMovementDate { get; set; }
        public int OrderLineId { get; set; }
        public int OrderSequence { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Deadline { get; set; }
        public int ProductId { get; set; }
        public int MachineId { get; set; }
        public string BarcodeNumber { get; set; }
        public string PalletNumber { get; set; }
        public int PalletId { get; set; }
        public int PalletCount { get; set; }
        public decimal PalletVolume { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PalletPrice { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int WarehouseId { get; set; }
        public int ShippingBasketId { get; set; }
        public string ShippingStatus { get; set; }
        public Guid UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int SalesRepresentativeId { get; set; }
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
