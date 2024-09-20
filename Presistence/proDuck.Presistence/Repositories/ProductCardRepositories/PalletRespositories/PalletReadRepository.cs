using proDuck.Application.Repositories.ProductCardInterfaces.PalletInterface;
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

namespace proDuck.Presistence.Repositories.ProductCardRepositories.PalletRespositories
{
    public class PalletReadRepository : ReadRepository<TBL_Pallet>, IPalletReadRepository
    {
        public PalletReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
