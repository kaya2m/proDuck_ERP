using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Features.Queries.Proposal.Proposal.GetByIdProposal;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductCard.ProductCard.GetByIdProduct
{
    public class GetByIdProductCardQueryHandler : IRequestHandler<GetByIdProductCardQueryRequest, GetByIdProductCardQueryResponse>
    {
        private readonly IProductCardReadRepository _productCardReadRepository;

        public GetByIdProductCardQueryHandler(IProductCardReadRepository productCardReadRepository)
        {
            _productCardReadRepository = productCardReadRepository;
        }

        public async Task<GetByIdProductCardQueryResponse> Handle(GetByIdProductCardQueryRequest request, CancellationToken cancellationToken)
        {
            var productCard = await _productCardReadRepository.GetByIdAsync(request.id, false);
            var isSuccessful = productCard != null;

            return new GetByIdProductCardQueryResponse
            {
                Data = productCard,
                IsSuccessful = isSuccessful,
                StatusCode = isSuccessful ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
            };
        }
    }
}
