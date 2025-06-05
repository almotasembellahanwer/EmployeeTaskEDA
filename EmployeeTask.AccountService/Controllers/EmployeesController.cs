using EmployeeTask.AccountService.AddressCommands;
using EmployeeTask.AccountService.Commands.EmployeeCommands;
using EmployeeTask.AccountService.EmployeeCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.AddressDTO;
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
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateRequest? employeeDTO)
        {
            if (employeeDTO is null)
                return BadRequest();

            EmployeeResponse response = await _sender.Send(new UpdateEmployeeCommand(employeeDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteEmployeeCommand(id));
            return NoContent();
        }
    }
}
