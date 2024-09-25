using proDuck.Application.Repositories.InvoiceFileInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.InvoiceRepositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFiles>, IInvoceFileReadRepository
    {
        public InvoiceFileReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
