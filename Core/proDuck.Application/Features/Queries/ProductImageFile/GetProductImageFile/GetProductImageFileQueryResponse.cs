using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductImageFile.GetProductImageFile
{
    public class GetProductImageFileQueryResponse
    {
        public string Path { get; set; }
        public Guid id { get; set; }
        public string FileName { get; set; }
    }
}
