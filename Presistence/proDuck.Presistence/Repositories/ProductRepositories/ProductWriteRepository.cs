using proDuck.Application.Repositories.ProductInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
