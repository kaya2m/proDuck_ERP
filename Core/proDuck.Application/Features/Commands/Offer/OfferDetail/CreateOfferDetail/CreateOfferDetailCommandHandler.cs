using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.ProposalDetail.CreateProposalDetail
{
    public class CreateProposalDetailCommandHandler : IRequestHandler<CreateProposalDetailCommandRequest, CreateProposalDetailCommandResponse>
    {
        private readonly IProposalDetailWriteRepository _ProposalDetailWriteRepository;
        private readonly IProposalReadRepository _ProposalReadRepository;
        public CreateProposalDetailCommandHandler(IProposalDetailWriteRepository ProposalDetailWriteRepository, IProposalReadRepository ProposalReadRepository)
        {
            _ProposalDetailWriteRepository = ProposalDetailWriteRepository;
            _ProposalReadRepository = ProposalReadRepository;
        }

        public async Task<CreateProposalDetailCommandResponse> Handle(CreateProposalDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Proposal = await _ProposalReadRepository.GetByIdAsync(request.ProposalId);
                if (Proposal == null)
                {
                    return new CreateProposalDetailCommandResponse
                    {
                        Message = "Proposal not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    var ProposalDetail = await _ProposalDetailWriteRepository.AddAsync(new()
                    {
                        SpecialCode = request.SpecialCode,
                        UnitPrice = request.UnitPrice,
                        Amount = request.Amount,
                        Discount = request.Discount,
                        DiscountedAmount = request.DiscountedAmount,
                        Quantity = request.Quantity,
                        Unit = request.Unit,
                        DeliveryDate = request.DeliveryDate,
                        Description = request.Description,
                        Image = request.Image,
                        Date = request.Date,
                        ProposalId = request.ProposalId,
                        ProductCardId = request.ProductCardId
                    });
                    await _ProposalDetailWriteRepository.SaveChangesAsync();
                    return new CreateProposalDetailCommandResponse
                    {
                        Data = ProposalDetail,
                        Message = "Proposal detail created successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status201Created,
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateProposalDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                };
            }  
        }
    }
}
