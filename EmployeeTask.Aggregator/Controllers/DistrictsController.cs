using EmployeeTask.Aggregator.Queries.DistrictQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.Aggregator.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllDistricts()
        {
            IEnumerable<DistrictResponseGet> districts = await _sender.Send(new GetDistrictsQuery());
            return Ok(districts);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDistrictByID(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID provided");
            DistrictResponseGet? district = await _sender.Send(new GetDistrictByIdQuery(id));
            if (district is null)
                return NotFound($"District with ID {id} not found");
            return Ok(district);
        }
    }
}
