using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class CityReadRepository : ICityReadRepository
    {
        private readonly proDuckDbContext _dbContext;

        public CityReadRepository(proDuckDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        DbSet<TBL_City> Table => _dbContext.Set<TBL_City>();

        public async Task<List<TBL_City>> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable().AsNoTracking();

            return await query.Where(x => x.CountryId == id).ToListAsync();
        }
    }
}
