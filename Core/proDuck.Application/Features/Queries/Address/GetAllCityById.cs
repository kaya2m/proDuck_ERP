using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.DTOs;
using proDuck.Application.Repositories.AddressInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proDuck.Application.Features.Queries.Address.GetAllCityById;

namespace proDuck.Application.Features.Queries.Address
{
    public class GetAllCityById : IRequestHandler<GetAllCityByIdRequest, GetAllCityByIdResponse>
    {
        private readonly ICityReadRepository _cityReadRepository;

        public GetAllCityById(ICityReadRepository cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetAllCityByIdResponse> Handle(GetAllCityByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cities = await _cityReadRepository.GetByIdAsync(request.countryId);
                return new GetAllCityByIdResponse
                {
                    Data = cities,
                    IsSuccessful=true,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {

                return new GetAllCityByIdResponse
                {
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                    Message = ex.Message
                };
            }
        }

        public class GetAllCityByIdRequest : IRequest<GetAllCityByIdResponse>
        {
            public int countryId { get; set; }
        }
        public class GetAllCityByIdResponse : ResponseDto<GetAllCityByIdResponse>
        {

        }
    }
}
