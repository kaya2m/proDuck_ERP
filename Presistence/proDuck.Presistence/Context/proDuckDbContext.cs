using proDuck.Domain.Entities;
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using proDuck.Domain.Entities.Customer;
using proDuck.Domain.Entities.Proposal;
using proDuck.Domain.Entities.Order;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Domain.Entities.SalesRepresentative;
using proDuck.Domain.Entities.Stock;
using proDuck.Domain.Entities.Machine;
using proDuck.Domain.Entities.Address;
using System.Diagnostics.Metrics;

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
        public DbSet<TBL_Proposal> Proposal { get; set; }
        public DbSet<TBL_ProposalDetails> ProposalDetails { get; set; }
        public DbSet<TBL_ProposalMeeting> ProposalMeetings { get; set; }
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
        public DbSet<TBL_City> Cities { get; set; }
        public DbSet<TBL_District> Districts { get; set; }
        public DbSet<TBL_Neighborhood> Neighborhoods { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreateDate = DateTime.Now;
                    data.Entity.Status = true;
                    data.Entity.UserCreated = "admin";
                }
                if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<TBL_Proposal>()
                .HasOne(o => o.Order)
                .WithOne(or => or.Proposal)
                .HasForeignKey<TBL_Order>(or => or.ProposalId);

            modelBuilder.Entity<TBL_City>()
               .HasMany(c => c.Districts)
               .WithOne(d => d.City)
               .HasForeignKey(d => d.CityId);

            modelBuilder.Entity<TBL_District>()
                .HasMany(d => d.Neighborhoods)
                .WithOne(n => n.District)
                .HasForeignKey(n => n.DistrictId);

            modelBuilder.Entity<TBL_Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<TBL_Country>()
                .HasMany(c => c.Districts)
                .WithOne(d => d.Country)
                .HasForeignKey(d => d.CountryId);

            modelBuilder.Entity<TBL_Country>()
                .HasMany(c => c.Neighborhoods)
                .WithOne(n => n.Country)
                .HasForeignKey(n => n.CountryId);

            modelBuilder.Entity<TBL_Customer>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Customer>()
                .HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Customer>()
                .HasOne(c => c.District)
                .WithMany()
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Customer>()
                .HasOne(c => c.Neighborhood)
                .WithMany()
                .HasForeignKey(c => c.NeighborhoodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Customer>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_ShippingAddress>()
                .HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_ShippingAddress>()
                .HasOne(c => c.District)
                .WithMany()
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_ShippingAddress>()
                .HasOne(c => c.Neighborhood)
                .WithMany()
                .HasForeignKey(c => c.NeighborhoodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Warehouse>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Warehouse>()
                .HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Warehouse>()
                .HasOne(c => c.District)
                .WithMany()
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBL_Warehouse>()
                .HasOne(c => c.Neighborhood)
                .WithMany()
                .HasForeignKey(c => c.NeighborhoodId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
