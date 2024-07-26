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
    public class FileWriteRespository : WriteRepository<Files>, IFileWriteRepository
    {
        public FileWriteRespository(proDuckDbContext dbContext) : base(dbContext)
        {
        }
    }
}
