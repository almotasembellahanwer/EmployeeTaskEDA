using EmployeeTask.Aggregator.Queries;
using EmployeeTask.Aggregator.Queries.AddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.Aggregator.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            IEnumerable<AddressResponse> addresses = await _sender.Send(new GetAddressesQuery());
            return Ok(addresses);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAddressByID(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID provided");
            AddressResponse? address = await _sender.Send(new GetAddressByIdQuery(id));
            if (address is null)
                return NotFound($"Address with ID {id} not found");
            return Ok(address);
        }
    }
}
