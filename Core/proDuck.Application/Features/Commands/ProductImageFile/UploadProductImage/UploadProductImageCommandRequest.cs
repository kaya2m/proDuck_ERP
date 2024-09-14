using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
{
    public Guid id { get; set; }
    public IFormFileCollection Files { get; set; }
}
