using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Proposal.Proposal.DeleteProposal
{
    public class DeleteProposalCommandHandler : IRequestHandler<DeleteProposalCommandRequest, DeleteProposalCommandResponse>
    {
        private readonly IProposalReadRepository _ProposalReadRepository;
        private readonly IProposalWriteRepository _ProposalWriteRepository;

        public DeleteProposalCommandHandler(IProposalReadRepository ProposalReadRepository, IProposalWriteRepository ProposalWriteRepository)
        {
            _ProposalReadRepository = ProposalReadRepository;
            _ProposalWriteRepository = ProposalWriteRepository;
        }

        public async Task<DeleteProposalCommandResponse> Handle(DeleteProposalCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Proposal = await _ProposalReadRepository.GetByIdAsync(request.id);
                if (Proposal == null)
                {
                    return new DeleteProposalCommandResponse
                    {
                        Message = "Proposal not found",
                        IsSuccessful = false
                    };
                }
                else
                {
                    Proposal.Status = false;
                    _ProposalWriteRepository.Update(Proposal);
                    await _ProposalWriteRepository.SaveChangesAsync();
                    return new DeleteProposalCommandResponse
                    {
                        Message = "Proposal deleted successfully",
                        IsSuccessful = true,
                        StatusCode = StatusCodes.Status204NoContent
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteProposalCommandResponse
                {
                    Message = ex.Message,
                    IsSuccessful = false,
                    StatusCode = ex.HResult
                };
            }
        }
    }
}
