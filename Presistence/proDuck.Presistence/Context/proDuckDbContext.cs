using proDuck.Domain.Entities;
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Domain.Entities.SalesRepresentative;
using proDuck.Domain.Entities.Stock;
using proDuck.Domain.Entities.Machine;

namespace proDuck.Persistence.Context
{
    public class proDuckDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public proDuckDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Files> Files { get; set; }
        public DbSet<ProductImageFiles> ProductImages { get; set; }
        public DbSet<TBL_Customer> Customers { get; set; }
        public DbSet<TBL_ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<TBL_Machine> Machines { get; set; }
        public DbSet<TBL_Offer> Offer { get; set; }
        public DbSet<TBL_OfferDetails> OfferDetails { get; set; }
        public DbSet<TBL_OfferMeeting> OfferMeetings { get; set; }
        public DbSet<TBL_PaymentType> PaymentTypes { get; set; }
        public DbSet<TBL_SalesType> SalesTypes { get; set; }
        public DbSet<TBL_VehicleType> VehicleTypes { get; set; }
        public DbSet<TBL_Order> Orders { get; set; }
        public DbSet<TBL_OrderDetails> OrderDetails { get; set; }
        public DbSet<TBL_Category> Categories { get; set; }
        public DbSet<TBL_ModelType> ModelTypes { get; set; }
        public DbSet<TBL_Pallet> Pallets { get; set; }
        public DbSet<TBL_ProductCard> ProductCards { get; set; }
        public DbSet<TBL_UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<TBL_SalesRepresentative> SalesRepresentatives { get; set; }
        public DbSet<TBL_StockMovement> StockMovements { get; set; }
        public DbSet<TBL_Warehouse> Warehouses { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreateDate = DateTime.UtcNow;
                    data.Entity.Status = true;
                    data.Entity.UserCreated = "admin";
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
