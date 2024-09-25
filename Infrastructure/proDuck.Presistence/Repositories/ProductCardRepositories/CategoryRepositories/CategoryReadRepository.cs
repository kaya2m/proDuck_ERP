using proDuck.Application.Repositories.ProductCardInterfaces.CategoryInterface;
using proDuck.Application.Repositories.ProductImageFileInterface;
using proDuck.Domain.Entities;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProductCardRepositories.CategoryRepositories
{
    public class CategoryReadRepository : ReadRepository<TBL_Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
