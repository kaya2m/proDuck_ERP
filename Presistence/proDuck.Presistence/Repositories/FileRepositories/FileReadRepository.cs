using proDuck.Application.Repositories.FileInterface;
using proDuck.Domain.Entities;
using proDuck.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Persistence.Repositories.FileRepositories
{
    public class FileReadRepository : ReadRepository<Files>, IFileReadRepository
    {
        public FileReadRepository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
