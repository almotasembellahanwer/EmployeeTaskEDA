using EmployeeTask.AccountService.AddressCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ISender _sender;

        public AddressesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressAddRequest? addressDTO)
        {
            if (addressDTO is null)
                return BadRequest();

            AddressResponse response = await _sender.Send(new AddAddressCommand(addressDTO));
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(AddressUpdateRequest? addressDTO)
        {
            if (addressDTO is null)
                return BadRequest();

            AddressResponse response = await _sender.Send(new UpdateAddressCommand(addressDTO));
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (id <= 0)
                return BadRequest();

            bool response = await _sender.Send(new DeleteAddressCommand(id));
            return NoContent();
        }
    }
}
