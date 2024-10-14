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
    public class CountryReadRepository : ICountryReadRepository
    {
        private readonly proDuckDbContext _dbContext;

        public CountryReadRepository(proDuckDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        DbSet<TBL_Country> Table => _dbContext.Set<TBL_Country>();

        public async Task<List<TBL_Country>> GetAll()
        {
            var query = Table.AsQueryable().AsNoTracking();
            return await query.ToListAsync();
        }
    }
}
