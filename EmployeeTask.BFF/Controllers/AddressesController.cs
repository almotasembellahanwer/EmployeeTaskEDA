using EmployeeTask.BFF.HttpClients;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO;
using SharedModels.DTO.AddressDTO;
using System.Net;

namespace EmployeeTask.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AggregatorServiceClient _aggregatorClient;
        private readonly AccountServiceClient _accountClient;
        private readonly APIResponse _response;

        public AddressesController(AggregatorServiceClient aggregatorClient, AccountServiceClient accountClient)
        {
            _aggregatorClient = aggregatorClient;
            _accountClient = accountClient;
            _response = new();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllAddresses()
        {
            IEnumerable<AddressResponse>? addresses = await _aggregatorClient.GetAllAddresses();
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = addresses;
            return Ok(_response);
        }
        [HttpGet("Get/{addressID:int}", Name = "GetAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAddress(int addressID)
        {
            if (addressID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AddressResponse? address = await _aggregatorClient.GetAddressByID(addressID);
            if (address is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = address;
            return Ok(_response);
        }
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddAddress([FromBody] AddressAddRequest? addressRequest)
        {
            if (addressRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AddressResponse? address = await _accountClient.AddAddress(addressRequest);
            if (address is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = address;
            return CreatedAtRoute("GetAddress", new { addressID = address.AddressID }, _response);
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAddress([FromBody] AddressUpdateRequest? addressRequest)
        {
            if (addressRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AddressResponse? address = await _accountClient.UpdateAddress(addressRequest);
            if (address is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = address;
            return Ok(_response);
        }
        [HttpDelete("Delete/{addressID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteAddress(int addressID)
        {
            if (addressID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            bool isDeleted = await _accountClient.DeleteAddress(addressID);
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
