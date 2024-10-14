using Microsoft.EntityFrameworkCore;
using proDuck.Application.Repositories.AddressInterface;
using proDuck.Domain.Entities.Address;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.AddressRepositories
{
    public class NeighborhoodReadRepository : INeighborhoodReadRepository
    {
        private readonly proDuckDbContext _dbContext;

        public NeighborhoodReadRepository(proDuckDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        DbSet<TBL_Neighborhood> Table => _dbContext.Set<TBL_Neighborhood>();
        public async Task<List<TBL_Neighborhood>> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable().AsNoTracking();

            return await query.Where(x => x.DistrictId == id).ToListAsync();
        }
    }
}
