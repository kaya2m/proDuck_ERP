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
    public class DistrictReadRepository : IDistrictReadRepository
    {
        private readonly proDuckDbContext _dbContext;

        public DistrictReadRepository(proDuckDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        DbSet<TBL_District> Table => _dbContext.Set<TBL_District>();
        public async Task<List<TBL_District>> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable().AsNoTracking();

            return await query.Where(x => x.CityId == id).ToListAsync();
        }
    }
}
