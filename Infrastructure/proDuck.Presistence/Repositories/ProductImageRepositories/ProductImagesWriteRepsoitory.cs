using proDuck.Application.Repositories;
using proDuck.Application.Repositories.ProductImageFileInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.ProductImageRepositories
{
    public class ProductImagesWriteRepsoitory : WriteRepository<ProductImageFiles>, IProductImageFileWriteRepository
    {
        public ProductImagesWriteRepsoitory(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
