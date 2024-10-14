using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.DTOs;
using proDuck.Application.Repositories.AddressInterface;
using static proDuck.Application.Features.Queries.Address.GetAllNeighborhoodById;

namespace proDuck.Application.Features.Queries.Address
{
    public class GetAllNeighborhoodById : IRequestHandler<GetAllNeighborhoodByIdRequest, GetAllNeighborhoodByIdResponse>
    {
        private readonly INeighborhoodReadRepository _neighborhoodReadRepository;

        public GetAllNeighborhoodById(INeighborhoodReadRepository NeighborhoodReadRepository)
        {
            _neighborhoodReadRepository = NeighborhoodReadRepository;
        }

        public async Task<GetAllNeighborhoodByIdResponse> Handle(GetAllNeighborhoodByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var neighborhoods = await _neighborhoodReadRepository.GetByIdAsync(request.districtId);
                return new GetAllNeighborhoodByIdResponse
                {
                    Data = neighborhoods,
                    IsSuccessful = true,
                    StatusCode =  StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {

                return new GetAllNeighborhoodByIdResponse
                {
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                    Message = ex.Message
                };
            }
        }

        public class GetAllNeighborhoodByIdRequest : IRequest<GetAllNeighborhoodByIdResponse>
        {
            public int districtId { get; set; }
        }
        public class GetAllNeighborhoodByIdResponse : ResponseDto<GetAllNeighborhoodByIdResponse>
        {

        }
    }
}
