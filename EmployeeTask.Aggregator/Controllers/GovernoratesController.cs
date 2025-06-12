using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllGovernorates()
        {
            IEnumerable<GovernorateResponse> governorates = await _sender.Send(new GetGovernoratesQuery());
            return Ok(governorates);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGovernorateByID(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID provided");
            GovernorateResponse? governorate = await _sender.Send(new GetGovernorateByIdQuery(id));
            if (governorate is null)
                return NotFound($"Governorate with ID {id} not found");
            return Ok(governorate);
        }
    }
}
