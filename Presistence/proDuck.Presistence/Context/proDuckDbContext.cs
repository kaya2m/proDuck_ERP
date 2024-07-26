using proDuck.Domain.Entities;
using proDuck.Domain.Entities.Common;
using proDuck.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace proDuck.Persistence.Context
{
    public class proDuckDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public proDuckDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set;}
        
        public DbSet<Files> Files { get; set; }
        public DbSet<ProductImageFiles> ProductImages { get; set; }
        public DbSet<InvoiceFiles> Invoices { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _=> DateTime.UtcNow
                }; ;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
