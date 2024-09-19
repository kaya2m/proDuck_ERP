using proDuck.Application.Repositories.OfferInterfaces.OfferInterface;
using proDuck.Application.Repositories.OrderInterface;
using proDuck.Domain.Entities.Offer;
using proDuck.Domain.Entities.Order;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.OffersRepositories.OfferRepositories
{
    public class OfferWriteRepository : WriteRepository<TBL_Offer>, IOfferWriteRepository
    {
        public OfferWriteRepository(proDuckDbContext dbContext) : base(dbContext)
        { }
    }
}
