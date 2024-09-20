using proDuck.Domain.Entities.ProductCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface
{
    public interface IProductCardWriteRepository : IWriteRepository<TBL_ProductCard>
    {
    }
}
