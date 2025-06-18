using EmployeeTask.Aggregator.Queries.DepartmentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public DepartmentsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments([FromQuery] DepartmentSearchRequest? searchRequest)
        {
            if (searchRequest is null)
                return BadRequest("Search Request cannot be null");
            IEnumerable<DepartmentResponseGet> departments = await _sender.Send(new GetDepartmentsQuery(searchRequest));
            return Ok(departments);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentByID(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID provided");
            DepartmentResponseGet? department = await _sender.Send(new GetDepartmentByIdQuery(id));
            if (department is null)
                return NotFound($"Department with ID {id} not found");
            return Ok(department);
        }
    }
}
