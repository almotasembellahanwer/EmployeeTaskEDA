using EmployeeTask.BFF.HttpClients;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO;
using SharedModels.DTO.DistrictDTO;
using System.Net;

namespace EmployeeTask.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly AggregatorServiceClient _aggregatorClient;
        private readonly AccountServiceClient _accountClient;
        private readonly APIResponse _response;

        public DistrictsController(AggregatorServiceClient aggregatorClient, AccountServiceClient accountClient)
        {
            _aggregatorClient = aggregatorClient;
            _accountClient = accountClient;
            _response = new();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllDistricts()
        {
            IEnumerable<DistrictResponse>? districts = await _aggregatorClient.GetAllDistricts();
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = districts;
            return Ok(_response);
        }
        [HttpGet("Get/{districtID:int}", Name = "GetDistrict")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDistrict(int districtID)
        {
            if (districtID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DistrictResponse? district = await _aggregatorClient.GetDistrictByID(districtID);
            if (district is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = district;
            return Ok(_response);
        }
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddDistrict([FromBody] DistrictAddRequest? districtRequest)
        {
            if (districtRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DistrictResponse? district = await _accountClient.AddDistrict(districtRequest);
            if (district is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = district;
            return CreatedAtRoute("GetDistrict", new { districtID = district.DistrictID }, _response);
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDistrict([FromBody] DistrictUpdateRequest? districtRequest)
        {
            if (districtRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DistrictResponse? district = await _accountClient.UpdateDistrict(districtRequest);
            if (district is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = district;
            return Ok(_response);
        }
        [HttpDelete("Delete/{districtID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteDistrict(int districtID)
        {
            if (districtID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            bool isDeleted = await _accountClient.DeleteDistrict(districtID);
            if (!isDeleted)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            return NoContent();
        }
    }
}
