using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.ProposalDetail.DeleteProposalDetail
{
    public class DeleteProposalDetailCommandHandler : IRequestHandler<DeleteProposalDetailCommandRequest, DeleteProposalDetailCommandResponse>
    {
        private readonly IProposalDetailReadRepository _ProposalDetailReadRepository;
        private readonly IProposalDetailWriteRepository _ProposalDetailWriteRepository;

        public DeleteProposalDetailCommandHandler(IProposalDetailWriteRepository ProposalDetailWriteRepository)
        {
            _ProposalDetailWriteRepository = ProposalDetailWriteRepository;
        }

        public async Task<DeleteProposalDetailCommandResponse> Handle(DeleteProposalDetailCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var ProposalDetail = await _ProposalDetailReadRepository.GetByIdAsync(request.id);
                if (ProposalDetail == null)
                {
                    return new DeleteProposalDetailCommandResponse
                    {
                        Message = "Proposal Detail not found",
                        IsSuccessful = false,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                else
                {
                    ProposalDetail.Status = false;
                    _ProposalDetailWriteRepository.Update(ProposalDetail);
                    await _ProposalDetailWriteRepository.SaveChangesAsync();
                    return new DeleteProposalDetailCommandResponse
                    {
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status200OK
                    };
                }

            }
            catch (Exception ex)
            {
                return new DeleteProposalDetailCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
