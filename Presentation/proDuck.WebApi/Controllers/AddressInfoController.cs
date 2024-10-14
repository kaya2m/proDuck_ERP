using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proDuck.Application.Features.Queries.Address;
using static proDuck.Application.Features.Queries.Address.GetAllCityById;
using static proDuck.Application.Features.Queries.Address.GetAllDistrictById;
using static proDuck.Application.Features.Queries.Address.GetAllNeighborhoodById;

namespace proDuck.WebApi.Controllers
{
    [Route("api/addressInfo")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AddressInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountry([FromRoute] GetAllCountryByIdRequest getAllCountryByIdRequest)
        {
            GetAllCountryByIdResponse response = await _mediator.Send(getAllCountryByIdRequest);
            return Ok(response);
        }

        [HttpGet("countries/{countryId}/cities")]
        public async Task<IActionResult> GetAllCityById([FromRoute] GetAllCityByIdRequest getAllCityByIdRequest)
        {
            GetAllCityByIdResponse response = await _mediator.Send(getAllCityByIdRequest);
            return Ok(response);
        }

        [HttpGet("cities/{cityId}/districts")]
        public async Task<IActionResult> GetAllDistrictById([FromRoute] GetAllDistrictByIdRequest getAllDistrictByIdRequest)
        {
            GetAllDistrictByIdResponse response = await _mediator.Send(getAllDistrictByIdRequest);
            return Ok(response);
        }

        [HttpGet("districts/{districtId}/neighborhoods")]
        public async Task<IActionResult> GetAllNeighborhoodById([FromRoute] GetAllNeighborhoodByIdRequest getAllNeighborhoodByIdRequest)
        {
            GetAllNeighborhoodByIdResponse response = await _mediator.Send(getAllNeighborhoodByIdRequest);
            return Ok(response);
        }
    }
}
