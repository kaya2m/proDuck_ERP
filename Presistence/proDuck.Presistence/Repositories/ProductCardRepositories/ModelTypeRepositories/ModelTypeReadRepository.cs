using proDuck.Application.Repositories.ProductCardInterfaces.ModelTypeInterface;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;

namespace proDuck.Presistence.Repositories.ProductCardRepositories.ModelTypeRepositories
{
    public class ModelTypeReadRepository : ReadRepository<TBL_ModelType>, IModelTypeReadRepository
    {
        public ModelTypeReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
