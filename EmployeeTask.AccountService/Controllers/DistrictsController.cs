using EmployeeTask.AccountService.DistrictCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly ISender _sender;

        public DistrictsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> AddDistrict([FromBody] DistrictAddRequest? districtDTO)
        {
            if (districtDTO is null)
                return BadRequest();

            DistrictResponse response = await _sender.Send(new AddDistrictCommand(districtDTO));
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDistrict([FromBody] DistrictUpdateRequest? districtDTO)
        {
            if (districtDTO is null)
                return BadRequest();

            DistrictResponse response = await _sender.Send(new UpdateDistrictCommand(districtDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteDistrictCommand(id));
            return NoContent();
        }
    }
}
