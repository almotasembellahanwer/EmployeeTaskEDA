using EmployeeTask.AccountService.AreaCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.AreaDTO;

namespace EmployeeTask.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly ISender _sender;

        public AreasController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> AddArea([FromBody] AreaAddRequest? areaDTO)
        {
            if (areaDTO is null)
                return BadRequest();

            AreaResponse response = await _sender.Send(new AddAreaCommand(areaDTO));
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateArea([FromBody] AreaUpdateRequest? areaDTO)
        {
            if (areaDTO is null)
                return BadRequest();

            AreaResponse response = await _sender.Send(new UpdateAreaCommand(areaDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteAreaCommand(id));
            return NoContent();
        }
    }
}
