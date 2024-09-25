using proDuck.Application.Repositories.ProductCardInterfaces.CategoryInterface;
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
    public class CategoryWriteRepository : WriteRepository<TBL_Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
