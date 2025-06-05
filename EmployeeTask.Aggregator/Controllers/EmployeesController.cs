using EmployeeTask.Aggregator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<EmployeeResponseGet> employees = await _sender.Send(new GetEmployeesQuery());
            return Ok(employees);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID provided");
            EmployeeResponseGet? employee = await _sender.Send(new GetEmployeeByIdQuery(id));
            if (employee is null)
                return NotFound($"Employee with ID {id} not found");
            return Ok(employee);
        }
    }
}
