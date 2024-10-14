using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.DTOs;
using proDuck.Application.Repositories.AddressInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proDuck.Application.Features.Queries.Address.GetAllDistrictById;

namespace proDuck.Application.Features.Queries.Address
{
   public class GetAllDistrictById : IRequestHandler<GetAllDistrictByIdRequest, GetAllDistrictByIdResponse>
    {
        private readonly IDistrictReadRepository _districtReadRepository;

        public GetAllDistrictById(IDistrictReadRepository DistrictReadRepository)
        {
            _districtReadRepository = DistrictReadRepository;
        }

        public async Task<GetAllDistrictByIdResponse> Handle(GetAllDistrictByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var districts = await _districtReadRepository.GetByIdAsync(request.cityId);
                return new GetAllDistrictByIdResponse
                {
                    Data = districts,
                    IsSuccessful=true,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {

                return new GetAllDistrictByIdResponse
                {
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                    Message = ex.Message
                };
            }
        }

        public class GetAllDistrictByIdRequest : IRequest<GetAllDistrictByIdResponse>
        {
            public int cityId { get; set; }
        }
        public class GetAllDistrictByIdResponse : ResponseDto<GetAllDistrictByIdResponse>
        {

        }
    }
}
