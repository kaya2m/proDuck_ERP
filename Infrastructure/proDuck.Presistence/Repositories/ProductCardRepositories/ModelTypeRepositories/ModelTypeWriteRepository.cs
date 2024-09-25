using proDuck.Application.Repositories.ProductCardInterfaces.ModelTypeInterface;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProductCardRepositories.ModelTypeRepositories
{
    public class ModelTypeWriteRepository : WriteRepository<TBL_ModelType>, IModelTypeWriteRepository
    {
        public ModelTypeWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
