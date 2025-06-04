using EmployeeTask.AccountService.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.Controllers
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

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeAddRequest? employeeDTO)
        {
            if(employeeDTO is null)
            {
                return BadRequest();
            }
            EmployeeResponse response = await _sender.Send(new AddEmployeeCommand(employeeDTO));
            return Ok(response);
        }
    }
}
