using SharedModels.DTO.EmployeeDTO;
using System.Net;
using System.Net.Http;
namespace EmployeeTask.BFF.HttpClients
{
    public class AggregatorServiceClient
    {
        private readonly HttpClient _httpClient;

        public AggregatorServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeeResponse>?> GetAllEmployees()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Employees");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
                }
                else
                {
                    throw new HttpRequestException("invalid response", null, response.StatusCode);
                }
            }

            IEnumerable<EmployeeResponse>? employeeResponse = await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeResponse>>();
            if (employeeResponse is null)
                return new List<EmployeeResponse>();
            return employeeResponse;
        }
    }
}
