using EmployeeTask.Aggregator.Queries.AreaQueries;
using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            IEnumerable<AreaResponseGet> areas = await _sender.Send(new GetAreasQuery());
            return Ok(areas);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAreaByID(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID provided");
            AreaResponseGet? area = await _sender.Send(new GetAreaByIdQuery(id));
            if (area is null)
                return NotFound($"Area with ID {id} not found");
            return Ok(area);
        }
    }
}
