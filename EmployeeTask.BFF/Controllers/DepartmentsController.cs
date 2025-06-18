using EmployeeTask.BFF.HttpClients;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO;
using SharedModels.DTO.DepartmentDTO;
using System.Net;

namespace EmployeeTask.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AggregatorServiceClient _aggregatorClient;
        private readonly AccountServiceClient _accountClient;
        private readonly APIResponse _response;

        public DepartmentsController(AggregatorServiceClient aggregatorClient, AccountServiceClient accountClient)
        {
            _aggregatorClient = aggregatorClient;
            _accountClient = accountClient;
            _response = new();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllDepartments()
        {
            IEnumerable<DepartmentResponse>? departments = await _aggregatorClient.GetAllDepartments();
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = departments;
            return Ok(_response);
        }
        [HttpGet("Get/{departmentID:int}", Name = "GetDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDepartment(int departmentID)
        {
            if (departmentID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DepartmentResponse? department = await _aggregatorClient.GetDepartmentByID(departmentID);
            if (department is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = department;
            return Ok(_response);
        }
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddDepartment([FromBody] DepartmentAddRequest? departmentRequest)
        {
            if (departmentRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DepartmentResponse? department = await _accountClient.AddDepartment(departmentRequest);
            if (department is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = department;
            return CreatedAtRoute("GetDepartment", new { departmentID = department.DepartmentID }, _response);
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDepartment([FromBody] DepartmentUpdateRequest? departmentRequest)
        {
            if (departmentRequest is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            DepartmentResponse? department = await _accountClient.UpdateDepartment(departmentRequest);
            if (department is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = department;
            return Ok(_response);
        }
        [HttpDelete("Delete/{departmentID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteDepartment(int departmentID)
        {
            if (departmentID == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            bool isDeleted = await _accountClient.DeleteDepartment(departmentID);
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
