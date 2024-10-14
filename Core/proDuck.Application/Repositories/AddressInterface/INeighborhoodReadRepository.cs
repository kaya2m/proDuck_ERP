using Microsoft.EntityFrameworkCore.Metadata.Internal;
using proDuck.Domain.Entities.Address;
using proDuck.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Repositories.AddressInterface
{
    public interface INeighborhoodReadRepository 
    {
        Task<List<TBL_Neighborhood>> GetByIdAsync(int id);
    }
}
