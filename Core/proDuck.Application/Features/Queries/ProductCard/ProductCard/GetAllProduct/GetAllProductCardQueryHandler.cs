using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using proDuck.Application.Features.Queries.Proposal.Proposal.GetAllProposal;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.ProductCard.ProductCard.GetAllProduct
{
    public class GetAllProductCardQueryHandler : IRequestHandler<GetAllProductCardQueryRequest, GetAllProductCardQueryResponse>
    {
        private readonly IProductCardReadRepository _productCardReadRepository;

        public GetAllProductCardQueryHandler(IProductCardReadRepository productCardReadRepository)
        {
            _productCardReadRepository = productCardReadRepository;
        }

        public async Task<GetAllProductCardQueryResponse> Handle(GetAllProductCardQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productCards = _productCardReadRepository.GetAll(false);

                var totalCount = await productCards.CountAsync();

                var ProposalFilters = await productCards
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync();

                return new GetAllProductCardQueryResponse
                {
                    Data = productCards,
                    TotalCount = totalCount,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new GetAllProductCardQueryResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
