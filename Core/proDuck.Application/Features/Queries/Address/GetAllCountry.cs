using MediatR;
using Microsoft.AspNetCore.Http;
using proDuck.Application.DTOs;
using proDuck.Application.Repositories.AddressInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Queries.Address
{
    public class GetAllCountry : IRequestHandler<GetAllCountryByIdRequest, GetAllCountryByIdResponse>
    {
        private readonly ICountryReadRepository _countryReadRepository;

        public GetAllCountry(ICountryReadRepository countryReadRepository)
        {
            _countryReadRepository = countryReadRepository;
        }

        public async Task<GetAllCountryByIdResponse> Handle(GetAllCountryByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = await _countryReadRepository.GetAll();
                return new GetAllCountryByIdResponse
                {
                    Data = countries,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new GetAllCountryByIdResponse
                {
                    IsSuccessful = false,
                    StatusCode = ex.HResult,
                    Message = ex.Message
                };
            }
        }
    }
    public class GetAllCountryByIdRequest : IRequest<GetAllCountryByIdResponse>
    {
    }
    public class GetAllCountryByIdResponse : ResponseDto<GetAllCountryByIdResponse>
    {

    }
}
