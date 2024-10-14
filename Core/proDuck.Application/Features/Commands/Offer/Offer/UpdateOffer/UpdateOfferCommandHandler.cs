using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace proDuck.Application.Features.Commands.Proposal.Proposal.UpdateProposal;

public class UpdateProposalCommandHandler : IRequestHandler<UpdateProposalCommandRequest, UpdateProposalCommandResponse>
{
    private readonly IProposalReadRepository _ProposalReadRepository;
    private readonly IProposalWriteRepository _ProposalWriteRepository;

    public UpdateProposalCommandHandler(IProposalReadRepository ProposalReadRepository, IProposalWriteRepository ProposalWriteRepository)
    {
        _ProposalReadRepository = ProposalReadRepository;
        _ProposalWriteRepository = ProposalWriteRepository;
    }

    public async Task<UpdateProposalCommandResponse> Handle(UpdateProposalCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Proposal = await _ProposalReadRepository.GetByIdAsync(request.id);
            if (Proposal == null)
            {
                return new UpdateProposalCommandResponse
                {
                    Message = "Proposal not found",
                    IsSuccessful = false
                };
            }
            else
            {
                Proposal.Type = request.Type;
                Proposal.ProposalNumber = request.ProposalNumber;
                Proposal.CompanyNumber = request.CompanyNumber;
                Proposal.PaymentMethod = request.PaymentMethod;
                Proposal.PaymentTerm = request.PaymentTerm;
                Proposal.ContactPerson = request.ContactPerson;
                Proposal.Description = request.Description;
                Proposal.Unit = request.Unit;
                Proposal.TotalAmount = request.TotalAmount;
                Proposal.DiscountedTotalAmount = request.DiscountedTotalAmount;
                Proposal.Date = request.Date;
                Proposal.CustomerId = request.CustomerId;
                Proposal.OrderId = request.OrderId;
                Proposal.ShippingAddressId = request.ShippingAddressId;
                Proposal.MeetingId = request.MeetingId;
                Proposal.SalesRepresentativeId = request.SalesRepresentativeId;
                Proposal.VehicleTypeId = request.VehicleTypeId;
                Proposal.PaymentTypeId = request.PaymentTypeId;
                Proposal.SalesTypeId = request.SalesTypeId;

                _ProposalWriteRepository.Update(Proposal);
                await _ProposalWriteRepository.SaveChangesAsync();
                return new UpdateProposalCommandResponse
                {
                    Message = "Proposal deleted successfully",
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
        }
        catch (Exception ex)
        {
            return new UpdateProposalCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult
            };
        }
        
    }
}
