using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.ProposalDetail.UpdateProposalDetail
{
    public class UpdateProposalDetailCommandHandler : IRequestHandler<UpdateProposalDetailCommandRequest, UpdateProposalDetailCommandResponse>
    {
        private readonly IProposalDetailReadRepository _ProposalDetailReadRepository;
        private readonly IProposalDetailWriteRepository _ProposalDetailWriteRepository;

        public UpdateProposalDetailCommandHandler(IProposalDetailReadRepository ProposalDetailReadRepository, IProposalDetailWriteRepository ProposalDetailWriteRepository)
        {
            _ProposalDetailReadRepository = ProposalDetailReadRepository;
            _ProposalDetailWriteRepository = ProposalDetailWriteRepository;
        }

        public async Task<UpdateProposalDetailCommandResponse> Handle(UpdateProposalDetailCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ProposalDetail = await _ProposalDetailReadRepository.GetByIdAsync(request.id);

                if (ProposalDetail == null)
                {
                    return new UpdateProposalDetailCommandResponse
                    {
                        Message = "Proposal Detail not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    ProposalDetail.SpecialCode = request.SpecialCode;
                    ProposalDetail.UnitPrice = request.UnitPrice;
                    ProposalDetail.Amount = request.Amount;
                    ProposalDetail.Discount = request.Discount;
                    ProposalDetail.DiscountedAmount = request.DiscountedAmount;
                    ProposalDetail.Quantity = request.Quantity;
                    ProposalDetail.Unit = request.Unit;
                    ProposalDetail.DeliveryDate = request.DeliveryDate;
                    ProposalDetail.Description = request.Description;
                    ProposalDetail.Image = request.Image;
                    ProposalDetail.Date = request.Date;
                    ProposalDetail.ProposalId = request.ProposalId;
                    ProposalDetail.ProductCardId = request.ProductCardId;

                    _ProposalDetailWriteRepository.Update(ProposalDetail);
                    await _ProposalDetailWriteRepository.SaveChangesAsync();
                    return new UpdateProposalDetailCommandResponse
                    {
                        Message = "Proposal detail updated successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status200OK
                    };

                }
            }
            catch (Exception ex)
            {
                return new UpdateProposalDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
            
        }
    }
}
