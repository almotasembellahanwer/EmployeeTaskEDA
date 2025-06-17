using EmployeeTask.AccountService.DepartmentCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.AccountService.Controllers
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
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentAddRequest? departmentDTO)
        {
            if (departmentDTO is null)
                return BadRequest();

            DepartmentResponse response = await _sender.Send(new AddDepartmentCommand(departmentDTO));
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentUpdateRequest? departmentDTO)
        {
            if (departmentDTO is null)
                return BadRequest();

            DepartmentResponse response = await _sender.Send(new UpdateDepartmentCommand(departmentDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteDepartmentCommand(id));
            return NoContent();
        }
    }
}
