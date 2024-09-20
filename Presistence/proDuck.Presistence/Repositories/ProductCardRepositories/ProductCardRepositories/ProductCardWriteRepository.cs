using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProductCardRepositories.ProductCardRepositories
{
    public class ProductCardWriteRepository : WriteRepository<TBL_ProductCard>, IProductCardWriteRepository
    {
        public ProductCardWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
