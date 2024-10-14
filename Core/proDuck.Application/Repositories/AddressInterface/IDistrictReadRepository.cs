using proDuck.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.AddressInterface
{
    public interface IDistrictReadRepository
    {
        Task<List<TBL_District>> GetByIdAsync(int id);
    }
}
