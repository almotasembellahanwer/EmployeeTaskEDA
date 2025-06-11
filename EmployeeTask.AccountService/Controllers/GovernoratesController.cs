using EmployeeTask.AccountService.GovernorateCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernoratesController : ControllerBase
    {
        private readonly ISender _sender;

        public GovernoratesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> AddGovernorate([FromBody] GovernorateAddRequest? governorateDTO)
        {
            if (governorateDTO is null)
                return BadRequest();

            GovernorateResponse response = await _sender.Send(new AddGovernorateCommand(governorateDTO));
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGovernorate([FromBody] GovernorateUpdateRequest? governorateDTO)
        {
            if (governorateDTO is null)
                return BadRequest();

            GovernorateResponse response = await _sender.Send(new UpdateGovernorateCommand(governorateDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGovernorate(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteGovernorateCommand(id));
            return NoContent();
        }
    }
}
