using EmployeeTask.BFF.HttpClients;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO;
using SharedModels.DTO.AreaDTO;
using System.Net;

namespace EmployeeTask.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly AggregatorServiceClient _aggregatorClient;
        private readonly AccountServiceClient _accountClient;
        private readonly APIResponse _response;

        public AreasController(AggregatorServiceClient aggregatorClient, AccountServiceClient accountClient)
        {
            _aggregatorClient = aggregatorClient;
            _accountClient = accountClient;
            _response = new();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllAreas()
        {
            IEnumerable<AreaResponse>? areas = await _aggregatorClient.GetAllAreas();
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = areas;
            return Ok(_response);
        }
        [HttpGet("Get/{areaID:int}", Name = "GetArea")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetArea(int areaID)
        {
            if (areaID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AreaResponse? area = await _aggregatorClient.GetAreaByID(areaID);
            if (area is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = area;
            return Ok(_response);
        }
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddArea([FromBody] AreaAddRequest? areaRequest)
        {
            if (areaRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AreaResponse? area = await _accountClient.AddArea(areaRequest);
            if (area is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = area;
            return CreatedAtRoute("GetArea", new { areaID = area.AreaID }, _response);
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateArea([FromBody] AreaUpdateRequest? areaRequest)
        {
            if (areaRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            AreaResponse? area = await _accountClient.UpdateArea(areaRequest);
            if (area is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = area;
            return Ok(_response);
        }
        [HttpDelete("Delete/{areaID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteArea(int areaID)
        {
            if (areaID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            bool isDeleted = await _accountClient.DeleteArea(areaID);
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
