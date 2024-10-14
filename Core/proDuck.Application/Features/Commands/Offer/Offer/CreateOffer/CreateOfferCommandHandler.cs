using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using System;


namespace proDuck.Application.Features.Commands.Proposal.Proposal.CreateProposal;

public class CreateProposalCommandHandler : IRequestHandler<CreateProposalCommandRequest, CreateProposalCommandResponse>
{
    private readonly IProposalWriteRepository _ProposalWriteRepository;

    public CreateProposalCommandHandler(IProposalWriteRepository ProposalWriteRepository)
    {
        _ProposalWriteRepository = ProposalWriteRepository;
    }

    public async Task<CreateProposalCommandResponse> Handle(CreateProposalCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Proposal = await _ProposalWriteRepository.AddAsync(new()
            {
                Type = request.Type,
                ProposalNumber = request.ProposalNumber,
                CompanyNumber = request.CompanyNumber,
                PaymentMethod = request.PaymentMethod,
                PaymentTerm = request.PaymentTerm,
                ContactPerson = request.ContactPerson,
                Description = request.Description,
                Unit = request.Unit,
                TotalAmount = request.TotalAmount,
                DiscountedTotalAmount = request.DiscountedTotalAmount,
                Date = request.Date,
                CustomerId = request.CustomerId,
                OrderId = request.OrderId,
                ShippingAddressId = request.ShippingAddressId,
                MeetingId = request.MeetingId,
                SalesRepresentativeId = request.SalesRepresentativeId,
                VehicleTypeId = request.VehicleTypeId,
                PaymentTypeId = request.PaymentTypeId,
                SalesTypeId = request.SalesTypeId
            });
            await _ProposalWriteRepository.SaveChangesAsync();
            return new CreateProposalCommandResponse
            {
                Data = Proposal,
                Message = "Proposal created successfully",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
            };
        }
        catch (Exception ex)
        {
            return new CreateProposalCommandResponse
            {
                Message = ex.Message,
                IsSuccessful = false,
                StatusCode = ex.HResult,
            };
        }
        

    }
}
