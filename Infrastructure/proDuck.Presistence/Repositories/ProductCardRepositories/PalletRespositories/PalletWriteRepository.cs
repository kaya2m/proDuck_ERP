using proDuck.Application.Repositories.ProductCardInterfaces.PalletInterface;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
namespace proDuck.Presistence.Repositories.ProductCardRepositories.PalletRespositories;

public class PalletWriteRepository : WriteRepository<TBL_Pallet>, IPalletWriteRepository
{
    public PalletWriteRepository(proDuckDbContext dbContext) : base(dbContext)
    {
    }
}
