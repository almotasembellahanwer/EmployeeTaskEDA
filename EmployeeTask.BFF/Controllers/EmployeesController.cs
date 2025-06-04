using EmployeeTask.BFF.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AggregatorServiceClient _aggregatorClient;
        private readonly AccountServiceClient _accountClient;


        public EmployeesController(AggregatorServiceClient aggregatorClient, AccountServiceClient accountClient)
        {
            _aggregatorClient = aggregatorClient;
            _accountClient = accountClient;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeResponse>> GetAllEmployees()
        {
            IEnumerable<EmployeeResponse>? response = await _aggregatorClient.GetAllEmployees();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> AddEmployee([FromBody] EmployeeAddRequest employeeDTO)
        {
            EmployeeResponse? response = await _accountClient.AddEmployee(employeeDTO);
            return Ok(response);
        }
    }
}
