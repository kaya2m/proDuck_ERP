using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.OfferInterfaces.OfferInterface
{
   public interface IOfferWriteRepository : IWriteRepository<TBL_Offer>
    {
    }
}
